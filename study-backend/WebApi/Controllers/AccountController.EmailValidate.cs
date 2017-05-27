﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using Logic;
using Logic.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApi.Models;

namespace WebApi.Controllers
{
	public partial class AccountController
	{

        [HttpPost]
        public ApiResult EmailValidate([FromBody] string input)
        {
            var result = new ApiResult();

            try
            {
                if (input.Length > 40)
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Errors.Add(Logic.Resources.Errors.EmailMaxLengthError);
                }
                else if (!Regex.IsMatch(input, "([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})"))
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Errors.Add(Logic.Resources.Errors.EmailFormatError);
                }
                else
                {
                    using (var context = new StudyContext())
                    {
                        if (context.Users.Any(u => u.Email == input))
                        {
                            result.ResultStatus = ResultStatus.Failed;
                            result.Errors.Add(Logic.Resources.Errors.EmailDuplicateError);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Errors.Clear();
                result.ResultStatus = ResultStatus.Thrown;
                result.Errors.Add(Logic.Resources.Errors.UnhandledError);
            }
            
            return result;
        }
    }
}