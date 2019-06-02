using Cinema.Infrastructure.Dto;
using Cinema.Infrastructure.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Test
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void GetMovie()
        {
            var services = new Infrastructure.Services.MovieService(AutoMapperConfig.Initialize());
            var movie = services.Get(20);
            Assert.AreEqual("Lewiatan", movie.MovieTitle);
        }

        [TestMethod]
        public void AddMovie()
        {
            var movieDto = new MovieDto()
            {
                MovieTitle = "Lewiatan",
                MovieDescription = "W obliczu eksmisji Kola walczy ze skorumpowaną strukturą władzy.",
                CategoryName = "Thriller",
                Country = "Rosja",
                YearOfProduction = "2014",
                DateOfPremiere = new DateTime(2014, 11, 14)
            };

            var services = new Infrastructure.Services.MovieService(AutoMapperConfig.Initialize());
            var id = services.InsertOrUpdate(movieDto);
            var movieDb = services.Get(id);
            Assert.AreEqual(movieDb.MovieDescription, movieDto.MovieDescription);
        }

        [TestMethod]
        public void GetAllMovie()
        {
            var services = new Infrastructure.Services.MovieService(AutoMapperConfig.Initialize());
            IList<MovieDto> movies = services.GetAll();
            IList<MovieDto> list = new List<MovieDto>();
            list.Add(new MovieDto
            {
                MovieTitle = "Lewiatan",
                MovieDescription = "W obliczu eksmisji Kola walczy ze skorumpowaną strukturą władzy.",
                CategoryName = "Thriller",
                YearOfProduction = "2014",
                DateOfPremiere = new DateTime(2014 - 11 - 14)
            });
   

            Assert.AreEqual(list.ElementAt(0).CategoryName, movies.ElementAt(0).CategoryName);
        }
    }
}
