using Cinema.Infrastructure.Dto;
using Cinema.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Cinema.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        // GET: Customer
        [Route("api/customer/GetOrAddCustomer")]
        [HttpPost]
        public IHttpActionResult GetOrAddCustomer([FromBody] CustomerDto customer)
        {
            return Json(_customerService.GetOrAddByData(customer));
        }

        [HttpPost]
        public IHttpActionResult GetCustomer([FromBody] CustomerDto customer)
        {
            return Json(_customerService.GetByData(customer));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(_customerService.Get(id));
        }
    }
}