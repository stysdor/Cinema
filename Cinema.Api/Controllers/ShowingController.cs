using Cinema.Infrastructure.Dto;
using Cinema.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cinema.Api.Controllers
{
    public class ShowingController : ApiController
    {
        private IShowingService _showingService;

        public ShowingController(IShowingService showingService)
        {
            _showingService = showingService;
        }

        public IHttpActionResult Get(int id)
        {
            return Json(_showingService.Get(id));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(_showingService.GetAll());
        }

        [Route("api/showing/GetActuall/{n}")]
        [HttpGet]
        public IHttpActionResult GetActuall(int n)
        {
            return Json(_showingService.GetActuall(n));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] ShowingDto showing)
        {
            _showingService.InsertOrUpdate(showing);
            return Json(true);
        }

        [Route("api/showing/Delete")]
        [HttpPost]
        public IHttpActionResult Delete([FromBody] ShowingDto showing)
        {
            _showingService.Remove(showing.Id);
            return Json(true);
        }
    }
}
