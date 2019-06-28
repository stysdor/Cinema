using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain
{
    public class Showing : EntityBase
    {
        public Movie MovieId { get; set; }
        public Theatre TheatreId { get; set; }
        public DateTime ShowingDateTime { get; set; }

    }
}
