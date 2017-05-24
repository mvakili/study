using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class HomeController : ApiController
    {
        [HttpGet]
        public int Get()
        {
            return 2;
        }

        [HttpGet]
        public bool RegisterUser()
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "muhammad"
            };

            var result = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new AuthenticationContext())).CreateAsync(user, "123x#2@ss").Result;

            return result.Succeeded;
        }


    }
}
