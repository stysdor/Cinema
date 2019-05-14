using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain
{
    public class PersonalData : EntityBase
    {
        public string PersonalName { get; set; }
        public string PersonalSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
