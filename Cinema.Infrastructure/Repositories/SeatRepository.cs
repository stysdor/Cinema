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
    public class SeatRepository : ISeatRepository
    {
        public Seat Get(int id)
        {
            Seat seat = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                seat = db.Query<Seat>("SELECT * FROM Seat " +
                                                "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return seat;
        }

        public IList<Seat> GetAll()
        {
            IList<Seat> seats = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                seats = db.Query<Seat>("SELECT * FROM Seat ").ToList();
            }
            return seats;
        }
    }
}
