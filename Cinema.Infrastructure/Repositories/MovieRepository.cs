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
    public class MovieRepository : IMovieRepository
    {

        public Movie Get(int id)
        {
            Movie movie = null;
            Category category = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                category = db.Query<Category>($"SELECT Category.Id, Category.CategoryName FROM Movie " +
                                                $"INNER JOIN Category ON Category.Id = Movie.CategoryId WHERE Movie.Id = {id}").SingleOrDefault();
                movie = db.Query<Movie>("SELECT Id, MovieTitle, MovieDescription, Country, YearOfProduction, DateOfPremiere FROM Movie " +
                                                "WHERE Id =" + id, new { CategoryId = category}).SingleOrDefault();
            }
            return movie;
        }

        public IList<Movie> GetAll()
        {
            IList<Movie> movies = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                movies = db.Query<Movie, Category, Movie>("SELECT * FROM Movie INNER JOIN Category ON Movie.CategoryId = Category.Id", 
                    (movie, category) =>
                    {
                        movie.CategoryId = category;
                        return movie;
                    }, splitOn: "CategoryId")
                    .Distinct()
                    .ToList();
            }
            return movies;
        }

        public IList<Movie> GetMoviesByCategory(Category category)
        {
            int categoryId = category.Id;
            IList<Movie> movies = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                movies = db.Query<Movie>("SELECT Id, MovieTitle, MovieDescription, Country, YearOfProduction, DateOfPremiere FROM Movie " +
                            $"WHERE CategoryId = {categoryId}", new { CategoryId = category }).ToList();
            }
            return movies;
        }

        public int InsertOrUpdate(Movie item)
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

        private int Insert(Movie item, IDbConnection db)
        {
            int categoryId = item.CategoryId.Id;
            string sql = @"INSERT INTO Movie (MovieTitle, MovieDescription, CategoryId, Country, YearOfProduction, DateOfPremiere)"
                +$"Values (@MovieTitle, @MovieDescription, {categoryId}, @Country, @YearOfProduction, @DateOfPremiere);"
                +@"SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = db.Query<int>(sql, new
            {
                item.MovieTitle,
                item.MovieDescription,
                item.CategoryId,
                item.Country,
                item.YearOfProduction,
                item.DateOfPremiere
            }).Single();

            return id;
        }

        private int Update(Movie item, IDbConnection db)
        {
            const string sql = @"UPDATE Movie SET MovieTitle = @MovieTitle,
                MovieDescription = @MovieDescription,
                CategoryId = @CategoryId.Id,
                Country = @Country,
                YearOfProduction = @YearOfProduction,
                DateOfPremiere = @DateOfPremiere WHERE Id = @Id";
            var affectedRows = db.Execute(sql, new
            {
                item.Id,
                item.MovieTitle,
                item.MovieDescription,
                CategoryId = item.CategoryId.Id,
                item.Country,
                item.YearOfProduction,
                item.DateOfPremiere
            });
            return affectedRows;
        }

        public void Remove(int id)
        {
            string sql = "DELETE FROM Movie WHERE Id=@Id";
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                var affectedRows = db.Execute(sql, new { Id = id });
            }
        }
    }
}
