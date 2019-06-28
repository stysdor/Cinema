using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.gui.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.gui.Logic;
using Cinema.Infrastructure.Dto;

namespace Cinema.gui.Controllers.Tests
{
    [TestClass()]
    public class MovieControllerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var data = new ApiClient().GetData<List<MovieDto>>("api/Movie/Get");
            Assert.IsNotNull(data.ElementAt(0));
        }
    }
}