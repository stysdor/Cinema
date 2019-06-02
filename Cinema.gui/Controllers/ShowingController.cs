using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.gui.Controllers
{
    public class ShowingController : Controller
    {
        // GET: Showings
        public ActionResult Index()
        {
            return View();
        }
    }
}