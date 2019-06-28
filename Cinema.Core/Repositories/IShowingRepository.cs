using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Core.Domain;

namespace Cinema.Core.Repositories
{
    public interface IShowingRepository : IDataRepository<Showing>
    {
        IList<Showing> GetShowingsByDate(DateTime date);
        IList<Showing> GetShowingsByMovie(Movie movie);
        IList<Showing> GetActuall(int n);
    }
}
