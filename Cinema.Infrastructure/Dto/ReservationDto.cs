using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Dto
{
    public class ReservationDto
    {
        public int ShowingId { get; set; }
        public int SeatId { get; set; }
        public int ReservationStatusId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
    }
}
