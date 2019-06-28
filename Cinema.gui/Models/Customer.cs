using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.gui.Models
{
    public class Customer
    {
        [Required]
        [Display(Name = "Imię")]
        [MaxLength(50)]
        [MinLength(2)]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        [MaxLength(50)]
        [MinLength(2)]
        public string CustomerSurname { get; set; }

        [Display(Name = "Numer telefonu")]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }
    }
}