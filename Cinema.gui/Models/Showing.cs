using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.gui.Models
{
    public class Showing
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Film")]
        public int MovieId { get; set; }

        public string MovieTitle { get; set; }

        [Required]
        [Display(Name = "Nr sali")]
        public int TheatreId { get; set; }

        [Required]
        [Display(Name = "Data seansu")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy H:mm:ss tt}"), DataType(DataType.DateTime)]
        public DateTime ShowingDateTime { get; set; }
    }
}