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
    public class TheatreRepository : ITheatreRepository
    {
        public Theatre Get(int id)
        {
            Theatre theatre = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                theatre = db.Query<Theatre>("SELECT * FROM Theatre " +
                                                "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return theatre;
        }

        public IList<Theatre> GetAll()
        {
            IList<Theatre> theatres = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                theatres = db.Query<Theatre>("SELECT * FROM Theatre ").ToList();
            }
            return theatres;
        }
    }
}
