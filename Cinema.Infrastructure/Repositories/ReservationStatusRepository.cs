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
    public class ReservationStatusRepository : IReservationStatusRepository
    {
        public ReservationStatus Get(int id)
        {
            ReservationStatus status = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                status = db.Query<ReservationStatus>("SELECT * FROM ReservationStatus " +
                                                "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return status;
        }

        public IList<ReservationStatus> GetAll()
        {
            IList<ReservationStatus> status = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                status = db.Query<ReservationStatus>("SELECT * FROM ReservationStatus ").ToList();
            }
            return status;
        }
    }
}
