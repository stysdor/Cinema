using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Cinema.Core.Domain;
using Cinema.Core.Repositories;
using Dapper;

namespace Cinema.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category Get(int id)
        {
            Category category = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                category = db.Query<Category>("SELECT * FROM Category " +
                                                $"WHERE Id = {id} ", new { id }).SingleOrDefault();
            }
            return category;
        }

        public IList<Category> GetAll()
        {
            IList<Category> categories = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                categories = db.Query<Category>("SELECT * FROM Category ").ToList();
            }
            return categories;
        }

        public Category GetByName(string name)
        {
            Category category = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                try
                {
                    category = db.Query<Category>($"SELECT * FROM Category " +
                                                        $" WHERE CategoryName = '{name}'").First();
                }
                catch { }
               
            }
            return category;
        }

        public Category GetOrAddByName(string name)
        {
            int id;
            Category category = GetByName(name);
            if(category == null)
            {
                id = Insert(name);
                category = Get(id);
            }
            return category;
        }

        private int Insert(string name)
        {
            int id;
            string sql = $"INSERT INTO Category (CategoryName) Values ('{name}');" 
                + "SELECT CAST(SCOPE_IDENTITY() as int);";
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                id = db.Query<int>(sql, new {
                    CategoryName = name
                }).Single();
            }     
            return id;
        }
    }
}
