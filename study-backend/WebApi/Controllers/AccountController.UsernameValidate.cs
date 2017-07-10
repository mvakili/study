
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
        public ApiResult UsernameValidate([FromBody] string input)
        {
            return new DataJob
            {
                Do = (context, result) =>
                {
                    if (input.Length < 3)
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.UserNameMinLengthError);
                    }
                    else if (input.Length > 20)
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.UserNameMaxLengthError);
                    }
                    else if (!Regex.IsMatch(input, "([A-Za-z._0-9]+)"))
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.EmailFormatError);
                    }
                    else
                    {
                        if (!context.Users.Any(u => u.UserName == input)) return;
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.UserNameDuplicateError);
                    }

                }
            }.Run();

        }
    }
}