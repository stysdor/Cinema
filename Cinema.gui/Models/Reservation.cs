using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.gui.Models
{
    public class Reservation
    {
        [Required]
        public int ShowingId { get; set; }

        [Required]
        public int RowSeatId { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public int Id { get; set; }

    }
}