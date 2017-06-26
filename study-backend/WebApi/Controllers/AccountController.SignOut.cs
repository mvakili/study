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

        [HttpPost]
        public  ApiResult SignOut()
        {
            var result = new ApiResult();

            try
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    HttpContext.Current.Session.Remove("UserId");
                }
                return result;
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