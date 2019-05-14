using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain
{
    public class Employee : EntityBase
    {
        public PersonalData PersonalDataId { get; set; }
        public User UserId { get; set; }
    }
}
