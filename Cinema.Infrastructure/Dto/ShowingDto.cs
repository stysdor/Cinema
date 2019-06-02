using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Dto
{
    public class ShowingDto
    {
        public int MovieId { get; set; }
        public int TheatreId { get; set; }
        public DateTime ShowingDateTime { get; set; }
        public int SubtitleDubbingId { get; set; }
    }
}
