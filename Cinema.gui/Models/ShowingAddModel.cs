using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.gui.Models
{
    public class ShowingAddModel
    {
        public Showing Showing { get; set; }

        public List<SelectListItem> Movies;

        public ShowingAddModel()
        {
            Showing = new Showing();
            Movies = new List<SelectListItem>();
        }

    }
}