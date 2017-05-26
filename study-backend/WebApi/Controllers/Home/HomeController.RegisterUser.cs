using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApi.Models;

namespace WebApi.Controllers.Home
{
	public partial class HomeController
	{
        [HttpPost]
        public ApiResult RegisterUser()
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "muhammad"
            };

            var result = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new AuthenticationContext())).CreateAsync(user, "123x#2@ss").Result;

            return new ApiResult()
            {
                ResultStatus = (result.Succeeded) ? ResultStatus.Successful : ResultStatus.Failed,
                Errors = result.Errors
            };
        }
    }
}