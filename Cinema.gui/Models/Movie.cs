using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.gui.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tytuł")]
        [MaxLength(45)]
        [MinLength(2)]
        public string MovieTitle { get; set; }

        [Required]
        [Display(Name = "Opis filmu")]
        [MaxLength(500)]
        public string MovieDescription { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Kraj")]
        [MaxLength(45)]
        [MinLength(3)]
        public string Country { get; set; }

        [Display(Name = "Rok produkcji")]
        [MaxLength(4)]
        [MinLength(4)]
        public string YearOfProduction { get; set; }

        [Display(Name = "Data premiery")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPremiere { get; set; }
    }
}