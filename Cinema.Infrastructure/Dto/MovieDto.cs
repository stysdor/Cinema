using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Dto
{
    public class MovieDto
    {
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        public string CategoryName { get; set; }
        public string Country { get; set; }
        public string YearOfProduction { get; set; }
        public DateTime DateOfPremiere { get; set; }
    }
}
