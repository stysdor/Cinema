using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Core.Domain;

namespace Cinema.Core.Repositories
{
    public interface ICategoryRepository : IGetDataRepository<Category>
    {
        Category GetByName(string name);
        Category GetOrAddByName(string name);
    }
}
