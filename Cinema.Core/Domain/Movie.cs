﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain
{
    public class Movie : EntityBase
    {
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        public Category CategoryId { get; set; }
        public string Country { get; set; }
        public string YearOfProduction { get; set; }
        public DateTime DateOfPremiere { get; set; }

    }
}
