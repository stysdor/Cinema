using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Core.Domain;
using Cinema.Core.Repositories;

namespace Cinema.Infrastructure.Repositories
{
    public class PersonalDataRepository : IPersonalDataRepository
    {
        public PersonalData Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PersonalData> GetAll()
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdate(PersonalData item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
