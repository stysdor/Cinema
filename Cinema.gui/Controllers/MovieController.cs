using Cinema.gui.logic;
using Cinema.gui.Models;
using Cinema.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.gui.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var dataDto = new ApiClient().GetData<List<MovieDto>>("api/movie/Get");
            var data = new List<Movie>();
            foreach (MovieDto movie in dataDto)
            {
                data.Add(new Movie()
                {
                    MovieTitle = movie.MovieTitle,
                    MovieDescription = movie.MovieDescription,
                    CategoryName = movie.CategoryName,
                    Country = movie.Country,
                    DateOfPremiere = movie.DateOfPremiere,
                    YearOfProduction = movie.YearOfProduction
                });
            }
            return View(data);
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            return View();
        }

      
        public ActionResult EditMovie(Movie model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult AddMovie(Movie model)
        {
            if (ModelState.IsValid)
            {
                var result = new ApiClient().PostData<MovieDto>("api/movie/Post", new MovieDto()
                {
                    MovieTitle = model.MovieTitle,
                    MovieDescription = model.MovieDescription,
                    Country = model.Country,
                    CategoryName = model.CategoryName,
                    DateOfPremiere = model.DateOfPremiere,
                    YearOfProduction = model.YearOfProduction
                });
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
