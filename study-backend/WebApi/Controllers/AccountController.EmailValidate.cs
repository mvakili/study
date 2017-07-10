using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using Models;
using Models.Api;
using WebApi.Handlers;

namespace WebApi.Controllers
{
    public partial class AccountController
    {
        [HttpPost]

        //This method checks if user is valid to signup or not
        public ApiResult EmailValidate([FromBody] string input)
        {

            return new DataJob
            {
                Do = (context, result) =>
                {
                    if (input.Length > 40)
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.EmailMaxLengthError);
                    }
                    else if (!Regex.IsMatch(input, "([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})"))
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.EmailFormatError);
                    }
                    else
                    {
                        if (!context.Users.Any(u => u.Email == input)) return;
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.EmailDuplicateError);
                    }
                }
            }.Run();


        }
    }
}