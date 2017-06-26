using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ApiResult UsernameValidate([FromBody] string input)
        {
            var result = new ApiResult();

            try
            {
                if (!input.StartsWith("@"))
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Errors.Add(DAL.Resources.Errors.UserNameFormatError);
                } else
                {
                    input = input.Remove(0, 1);
                }

                if (input.Length < 3)
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Errors.Add(DAL.Resources.Errors.UserNameMinLengthError);
                }
                else if (input.Length > 20)
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Errors.Add(DAL.Resources.Errors.UserNameMaxLengthError);
                }
                else if (!Regex.IsMatch(input, "([A-Za-z._0-9]+)"))
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Errors.Add(DAL.Resources.Errors.EmailFormatError);
                }
                else
                {
                    using (var context = new StudyContext())
                    {
                        if (context.Users.Any(u => u.UserName == input))
                        {
                            result.ResultStatus = ResultStatus.Failed;
                            result.Errors.Add(DAL.Resources.Errors.UserNameDuplicateError);
                        }
                    }
                }
                return result;

            }
            catch (Exception)
            {
                result.Errors.Clear();
                result.ResultStatus = ResultStatus.Thrown;
                result.Errors.Add(DAL.Resources.Errors.UnhandledError);
                return result;
            }
            
            
        }
    }
}