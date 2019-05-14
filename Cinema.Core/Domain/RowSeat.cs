using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain
{
    public class RowSeat : EntityBase
    {
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }

    }
}
