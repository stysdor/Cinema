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
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Repertoire()
        {
            var data = new ApiClient().GetData<List<ShowingDto>>("api/showing/GetActuall/14");
            var list = new List<Showing>();
            foreach (ShowingDto show in data)
            {
                list.Add(new Showing()
                {
                    Id = show.Id,
                    MovieId = show.MovieId,
                    MovieTitle = show.MovieTitle,
                    TheatreId = show.TheatreId,
                    ShowingDateTime = show.ShowingDateTime
                });
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Tickets()
        {
            return RedirectToAction("Index","Reservation");
        }


    }
}