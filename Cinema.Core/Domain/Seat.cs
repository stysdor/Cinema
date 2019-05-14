using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain
{
    public class Seat : EntityBase
    {
        public Theatre TheatreId { get; set; }
        public RowSeat RowSeatId { get; set; }
    }
}
