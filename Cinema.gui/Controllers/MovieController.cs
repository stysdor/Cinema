using Cinema.gui.Logic;
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
            var data = new ApiClient().GetData<List<MovieDto>>("api/movie");
            var list = new List<Movie>();
            foreach (MovieDto movieIn in data) {
                list.Add(new Movie()
                {

                    CategoryName = movieIn.CategoryName,
                    Country = movieIn.Country,
                    MovieDescription = movieIn.MovieDescription,
                    MovieTitle = movieIn.MovieTitle,
                    Id = movieIn.Id,
                    YearOfProduction = movieIn.YearOfProduction
                });
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EditMovie(Movie model)
        {
            return View(model);
        }

        public ActionResult DeleteMovie(Movie model)
        {
            var result = new ApiClient().PostData<MovieDto>("api/movie/Delete", new MovieDto()
            {
                MovieDescription = model.MovieDescription,
                MovieTitle = model.MovieTitle,
                Id = model.Id,
                CategoryName = model.CategoryName,
                Country = model.Country,
                YearOfProduction = model.YearOfProduction
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddMovie(Movie model)
        {
            if (ModelState.IsValid)
            {
                var result = new ApiClient().PostData<MovieDto>("api/movie/Post", new MovieDto()
                {
                    Id = model.Id,
                    MovieTitle = model.MovieTitle,
                    MovieDescription = model.MovieDescription,
                    CategoryName = model.CategoryName,
                    Country = model.Country,
                    YearOfProduction = model.YearOfProduction
                });
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
