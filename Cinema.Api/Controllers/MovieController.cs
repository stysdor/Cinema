using Cinema.Infrastructure.Dto;
using Cinema.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cinema.Api.Controllers
{
    public class MovieController: ApiController
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IHttpActionResult Get(int id)
        {
            return Json(_movieService.Get(id));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(_movieService.GetAll());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] MovieDto movie)
        {
            _movieService.InsertOrUpdate(movie);
            return Json(true);
        }
    }
}