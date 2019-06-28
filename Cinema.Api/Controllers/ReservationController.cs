using Cinema.Infrastructure.Dto;
using Cinema.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cinema.Api.Controllers
{
    public class ReservationController : ApiController
    {

        private IReservationService _reservationService;

        public ReservationController(IReservationService reservationService, ICustomerService customerService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(_reservationService.GetAll());
        }

        [Route("api/reservation/GetSeats/{id}")]
        [HttpGet]
        public IHttpActionResult GetSeats(int id)
        {
            return Json(_reservationService.GetSeats(id));
        }

        [Route("api/Reservation/Post")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] ReservationDto reservation)
        {
            _reservationService.InsertOrUpdate(reservation);
            return Json(true); 
        }
        [Route("api/Reservation/Delete")]
        [HttpPost]
        public IHttpActionResult Delete([FromBody] ReservationDto reservation)
        {
            _reservationService.Remove(reservation.Id);
            return Json(true);
        }

        [Route("api/Reservation/Confirm")]
        [HttpPost]
        public IHttpActionResult Confirm([FromBody] ReservationDto reservation)
        {
            _reservationService.InsertOrUpdate(reservation);
            return Json(true);
        }
    }
}