using Cinema.gui.Logic;
using Cinema.gui.Models;
using Cinema.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.gui.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            var reservationsDto = new ApiClient().GetData<List<ReservationDto>>("api/Reservation/GetAll");
            var model = new List<CustomerReservationModel>();
            foreach (ReservationDto reservation in reservationsDto)
            {
                int id = reservation.CustomerId;

                var customer = new ApiClient().GetData<CustomerDto>($"api/customer/get/{id}");
                if (customer == null)
                {

                    model.Add(new CustomerReservationModel()
                    {
                        Reservation = new Reservation()
                        {
                            Id = reservation.Id,
                            Status = reservation.Status,
                            CustomerId = id,
                            RowSeatId = reservation.RowSeatId,
                            ShowingId = reservation.ShowingId
                        }
                    });
                }
                else
                {
                    model.Add(new CustomerReservationModel()
                    {
                        Reservation = new Reservation()
                        {
                            Id = reservation.Id,
                            Status = reservation.Status,
                            CustomerId = id,
                            RowSeatId = reservation.RowSeatId,
                            ShowingId = reservation.ShowingId
                        },
                        Customer = new Customer()
                        {
                            CustomerName = customer.CustomerName,
                            CustomerSurname = customer.CustomerSurname,
                            Email = customer.Email,
                            Phone = customer.Phone
                        }
                    });
                }
            }
            return View(model);
        }

        public ActionResult DeleteReservation(Reservation model)
        {
            var result = new ApiClient().PostData<ReservationDto>("api/Reservation/Delete", new ReservationDto()
            {
                Id = model.Id,
                CustomerId =model.CustomerId,
                Status = model.Status,
                RowSeatId = model.RowSeatId,
                ShowingId = model.ShowingId
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddReservation(CustomerReservationModel model)
        {
            if (ModelState.IsValid)
            {

                var customer = new ApiClient().PostData<CustomerDto, CustomerDto>("api/customer/GetOrAddCustomer", new CustomerDto() {
                    CustomerName = model.Customer.CustomerName,
                    CustomerSurname = model.Customer.CustomerSurname,
                    Email = model.Customer.Email,
                    Phone = model.Customer.Phone
                });
                var result1 = new ApiClient().PostData<ReservationDto>("api/Reservation/Post", new ReservationDto()
                {
                    ShowingId = model.Reservation.ShowingId,
                    RowSeatId = model.Reservation.RowSeatId,
                    CustomerId = customer.Id,
                    Status = 0,    

                });
                if (result1 == true) return RedirectToAction("Index");
            }

            List<RowSeatDto> seats = new ApiClient().GetData<List<RowSeatDto>>($"api/Reservation/GetSeats/{model.Reservation.ShowingId}");
            model.Seats = seats;
            return View(model);

        }

        [HttpGet]
        public ActionResult AddReservation(Showing showing)
        {
            var data = new Reservation()
            {
                ShowingId = showing.Id
            };

            CustomerReservationModel model = new CustomerReservationModel()
            {
                Reservation = data,
            };

            List<RowSeatDto> seats = new ApiClient().GetData<List<RowSeatDto>>($"api/Reservation/GetSeats/{showing.Id}");
            model.Seats = seats;
            return View(model);
        }

        public ActionResult ConfirmReservation(Reservation model)
        {
            var result = new ApiClient().PostData<ReservationDto>("api/Reservation/Confirm", new ReservationDto()
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Status = 1,
                RowSeatId = model.RowSeatId,
                ShowingId = model.ShowingId
            });
            return RedirectToAction("Index");
        }

    }
}