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
    public class RowSeatRepository : IRowSeatRepository
    {
        public RowSeat Get(int id)
        {
            RowSeat rowSeat = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                rowSeat = db.Query<RowSeat>("SELECT * FROM RowSeat " +
                                                "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return rowSeat;
        }

        public IList<RowSeat> GetAll()
        {
            IList<RowSeat> rowSeats = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                rowSeats = db.Query<RowSeat>("SELECT * FROM RowSeat ").ToList();
            }
            return rowSeats;
        }
    }
}
