using Cinema.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cinema.Api2.Controllers
{
    public class MovieController : ApiController
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

        public IHttpActionResult GetAll()
        {
            return Json(_movieService.GetAll());
        }
    }
}
