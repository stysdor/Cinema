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
    public class ReservationRepository : IReservationRepository
    {
        public Reservation Get(int id)
        {
            Reservation reservation = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                reservation = db.Query<Reservation>("SELECT * FROM Reservation " +
                                                $"WHERE Id ={id}", new { id }).SingleOrDefault();
            }
            return reservation;
        }

        public IList<Reservation> GetAll()
        {
            IList<Reservation> reservations = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                reservations = db.Query<Reservation>("SELECT * FROM Reservation ").ToList();
            }
            return reservations;
        }

        public IList<Reservation> GetReservationByCustomer(Customer customer)
        {
            IList<Reservation> reservations = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                reservations = db.Query<Reservation>("SELECT * FROM Reservation " +
                                                "WHERE CustomerId =" + customer.Id, new { customer.Id }).ToList();
            }
            return reservations;
        }

        public IList<Reservation> GetReservationByShowing(Showing showing)
        {
            IList<Reservation> reservations = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                reservations = db.Query<Reservation>("SELECT * FROM Reservation " +
                                                "WHERE ShowingId =" + showing.Id, new { showing.Id }).ToList();
            }
            return reservations;
        }

        public int InsertOrUpdate(Reservation item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        IList<Reservation> IReservationRepository.GetReservationByCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
