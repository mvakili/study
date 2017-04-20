using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi.Controllers
{
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

        [HttpPost]

        public bool Login([FromBody] string userId, [FromBody] string password)
        {
            var result = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new AuthenticationContext())).AddLogin(userId, new UserLoginInfo());
            return result.Succeeded;
        }

    }
}
