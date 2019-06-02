using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Core.Domain;
using Cinema.Core.Repositories;
using Dapper;

namespace Cinema.Infrastructure.Repositories
{
    public class ShowingRepository : IShowingRepository
    {
        public Showing Get(int id)
        {
            Showing showing = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                showing = db.Query<Showing>("SELECT * FROM Showing " +
                                                "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return showing;
        }

        public IList<Showing> GetAll()
        {
            IList<Showing> showings = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                showings = db.Query<Showing>("SELECT * FROM Showing").ToList();
            }
            return showings;
        }

        public IList<Showing> GetShowingsByDate(DateTime date)
        {
            IList<Showing> showings = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                showings = db.Query<Showing>("SELECT * FROM Showing" +
                                                "WHERE ShowingDate =" + date, new { date }).ToList();
            }
            return showings;
        }

        public IList<Showing> GetShowingsByMovie(Movie movie)
        {
            IList<Showing> showings = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                showings = db.Query<Showing>("SELECT * FROM Showing" +
                                                "WHERE MovieId =" + movie.Id, new { movie.Id }).ToList();
            }
            return showings;
        }

        public int InsertOrUpdate(Showing item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
