using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.gui.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Movie()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Showing()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Reservation()
        {
            return View();
        }
    }
}