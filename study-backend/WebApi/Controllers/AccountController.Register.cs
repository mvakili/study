using System;
using System.Linq;
using System.Web.Http;
using DAL.Entities;
using Models;
using Models.Api;
using WebApi.Handlers;

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

            return new DataJob
            {
                Do = (context, result) =>
                {
                    result = EmailValidate(input.Email);

                    if (result.ResultStatus != ResultStatus.Successful)
                    {
                        return;
                    }

                    result = UsernameValidate(input.Username);

                    if (result.ResultStatus != ResultStatus.Successful)
                    {
                        return;
                    }

                    if (input.Password != input.PasswordConfirm)
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.PasswordAndConfirmPasswordNotEqualError);
                        return;
                    }

                    if (input.Password.Length < 8)
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.PasswordMinLengthError);
                        return;
                    }

                    if (input.Password.Length > 20)
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.PasswordMaxLengthError);
                        return;
                    }



                        if (context.Users.Any(u => u.UserName == input.Username))
                        {
                            result.ResultStatus = ResultStatus.Failed;
                            result.Messages.Add(Models.Resources.Errors.UserNameDuplicateError);
                        }
                        else if (context.Users.Any(u => u.Email == input.Email))
                        {
                            result.ResultStatus = ResultStatus.Failed;
                            result.Messages.Add(Models.Resources.Errors.EmailDuplicateError);
                        }
                        else
                        {
                            context.Users.Add(new User
                            {
                                UserName = input.Username,
                                Email = input.Email,
                                Password = input.Password
                            });
                            context.SaveChanges();

                            result = SignIn(new SignInInput
                            {
                                Username = input.Username,
                                Password = input.Password,
                                RememberMe = true
                            });
                        }
                    }
                }.Run();

        }
    }
}