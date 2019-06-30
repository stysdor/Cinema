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
    public class ShowingController : Controller
    {
        // GET: Showings
        [HttpGet]
        public ActionResult Index()
        {
            var data = new ApiClient().GetData<List<ShowingDto>>("api/showing");
            var list = new List<Showing>();
            foreach (ShowingDto show in data) {
                list.Add(new Showing()
                {
                    Id = show.Id,
                    MovieId = show.MovieId,
                    MovieTitle = show.MovieTitle,
                    TheatreId = show.TheatreId,
                    ShowingDateTime = show.ShowingDateTime
                });
            }  
            return View(list);
        }

        public ActionResult DeleteShowing(Showing model)
        {
            var result = new ApiClient().PostData<ShowingDto>("api/Showing/Delete", new ShowingDto()
            {
                Id = model.Id,
                MovieId = model.MovieId,
                MovieTitle = model.MovieTitle,
                ShowingDateTime = model.ShowingDateTime,
                TheatreId = model.TheatreId
            });
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public ActionResult AddShowing()
        {
            ShowingAddModel model = new ShowingAddModel();
            var movies = new ApiClient().GetData<List<MovieDto>>("api/movie");
            foreach (var movie in movies)
            {
                model.Movies.Add(new SelectListItem()
                {
                    Text = movie.MovieTitle,
                    Value = movie.Id.ToString()
                });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddShowing(ShowingAddModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new ApiClient().PostData<ShowingDto>("api/showing/Post", new ShowingDto()
                {
                    Id = model.Showing.Id,
                    MovieId = model.Showing.MovieId,
                    TheatreId = 1,
                    ShowingDateTime = model.Showing.ShowingDateTime
                });
                return RedirectToAction("Index");
            }
            var movies = new ApiClient().GetData<List<MovieDto>>("api/movie");
            foreach (var movie in movies)
            {
                model.Movies.Add(new SelectListItem()
                {
                    Text = movie.MovieTitle,
                    Value = movie.Id.ToString()
                });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditShowing(Showing modelshowing)
        {
            ShowingAddModel model = new ShowingAddModel();
            model.Showing = modelshowing;
            var movies = new ApiClient().GetData<List<MovieDto>>("api/movie");
            foreach (var movie in movies)
            {
                model.Movies.Add(new SelectListItem()
                {
                    Text = movie.MovieTitle,
                    Value = movie.Id.ToString()
                });
            }
            return View(model);
        }
    }
}