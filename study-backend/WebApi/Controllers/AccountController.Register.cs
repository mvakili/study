using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using DAL;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApi.Models;

namespace WebApi.Controllers
{
	public partial class AccountController
	{
        public class RegisterInput
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string PasswordConfirm { get; set; }
        }


        [HttpPost]
        public ApiResult Register([FromBody] RegisterInput input)
        {
            var result = new ApiResult();
            try
            {
                result = EmailValidate(input.Email);

                if (result.ResultStatus != ResultStatus.Successful)
                {
                    return result;
                }

                result = UsernameValidate(input.Username);

                if (result.ResultStatus != ResultStatus.Successful)
                {
                    return result;
                }

                if (input.Password != input.PasswordConfirm)
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Errors.Add(DAL.Resources.Errors.PasswordAndConfirmPasswordNotEqualError);
                    return result;
                }

                if (input.Password.Length < 8)
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Errors.Add(DAL.Resources.Errors.PasswordMinLengthError);
                    return result;
                }

                if (input.Password.Length > 20)
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Errors.Add(DAL.Resources.Errors.PasswordMaxLengthError);
                    return result;
                }


                using (var context = new StudyContext())
                {
                    if (context.Users.Any(u => u.UserName == input.Username))
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Errors.Add(DAL.Resources.Errors.UserNameDuplicateError);
                        return result;
                    }
                    else if (context.Users.Any(u => u.Email == input.Email))
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Errors.Add(DAL.Resources.Errors.EmailDuplicateError);
                        return result;
                    }
                    else
                    {
                        context.Users.Add(new DAL.Entities.User
                        {
                            UserName = input.Username,
                            Email = input.Email,
                            Password = input.Password
                        });
                        context.SaveChanges();
                        return result;
                    }
                }
            } catch
            {
                result.Errors.Clear();
                result.ResultStatus = ResultStatus.Thrown;
                return result;
            }

        }
    }
}