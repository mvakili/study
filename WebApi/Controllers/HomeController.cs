using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public int Get()
        {
            return 2;
        }
    }
}
