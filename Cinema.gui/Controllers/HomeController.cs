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
        public ActionResult Today()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Repertoire()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cinema()
        {
            return View();
        }
    }
}