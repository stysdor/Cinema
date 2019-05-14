using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain
{
    public class Reservation :EntityBase
    {
        public Showing ShowingId { get; set; }
        public Seat SeatId { get; set; }
        public ReservationStatus ReservationStatusId { get; set; }
        public DateTime ReservationDate { get; set; }
        public Customer CustomerId { get; set; }
        public Employee EmployeeId { get; set; }
    }
}
