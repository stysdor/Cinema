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
    public class CustomerRepository : ICustomerRepository
    {
        public Customer Get(int id)
        {
            Customer customer = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                customer = db.Query<Customer>("SELECT * FROM Customer " +
                                                $"WHERE Id = {id} ", new { id }).SingleOrDefault();
            }
            return customer;
        }

        public IList<Customer> GetAll()
        {
            IList<Customer> customers = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                customers = db.Query<Customer>("SELECT * FROM Customer ").ToList();
            }
            return customers;
        }

        public int InsertOrUpdate(Customer item)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                if (item.Id > 0)
                    return Update(item, db);
                else
                    return Insert(item, db);
            }
        }

        private int Insert(Customer item, IDbConnection db)
        {

            string sql = @"INSERT INTO Customers (PersonalDataId) Values (@PersonalDataId);
                            SELECT CAST(SQOPE_IDENTITY() as int";
            var id = db.Query<int>(sql, new
            {
                item.PersonalDataId
            }).Single();
            return id;
        }

        private int Update(Customer item, IDbConnection db)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            string sql = $"DELETE FROM Customer WHERE Id= {id}";
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                var affectedRows = db.Execute(sql, new { Id = id });
            }
        }

  
    }
}
