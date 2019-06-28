using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Core.Domain;

namespace Cinema.Core.Repositories
{
    public interface ICustomerRepository : IGetDataRepository<Customer>
    {
        Customer GetByData(Customer customer);
        Customer GetOrAddByData(Customer customer);
    }
}
