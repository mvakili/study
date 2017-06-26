using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using DAL;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using WebApi.Models;

namespace WebApi.Controllers
{
    public partial class AccountController
    {
        public class SignInInput
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }

        [HttpPost]
        public  ApiResult SignIn([FromBody] SignInInput input)
        {
            var result = new ApiResult();

            try
            {
                using (var context = new StudyContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.UserName == input.Username && u.Password == input.Password);
                    if (user != null)
                    {
                        HttpContext.Current.Session["UserId"] = user.Id;
                        return result;
                    }
                    else
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Errors.Add(DAL.Resources.Errors.UserNotFound);
                        return result;
                    }
                }
            }
            catch
            {
                result.Errors.Clear();
                result.ResultStatus = ResultStatus.Thrown;
                return result;
            }
        }
    }
}