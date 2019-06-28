using Cinema.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.gui.Models
{
    public class CustomerReservationModel
    {
        public Reservation Reservation { get; set; }
        public Customer Customer { get; set; }

        public IList<RowSeatDto> Seats { get; set; }

    }
}