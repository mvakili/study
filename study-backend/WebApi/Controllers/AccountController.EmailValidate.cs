using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using DAL;
using WebApi.Models;

namespace WebApi.Controllers
{
    public partial class AccountController
	{
        [HttpPost]

        //This method checks if user is valid to signup or not
        public ApiResult EmailValidate([FromBody] string input)
        {
            var result = new ApiResult();
            try
            {
                if (input.Length > 40)
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Messages.Add(DAL.Resources.Errors.EmailMaxLengthError);
                }
                else if (!Regex.IsMatch(input, "([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})"))
                {
                    result.ResultStatus = ResultStatus.Failed;
                    result.Messages.Add(DAL.Resources.Errors.EmailFormatError);
                }
                else
                {
                    using (var context = new StudyContext())
                    {
                        if (context.Users.Any(u => u.Email == input))
                        {
                            result.ResultStatus = ResultStatus.Failed;
                            result.Messages.Add(DAL.Resources.Errors.EmailDuplicateError);
                        }
                        else
                        {
                            
                        }
                    }
                }

            }
            catch
            {
                result.Messages.Clear();
                result.ResultStatus = ResultStatus.Thrown;
                result.Messages.Add(DAL.Resources.Errors.UnhandledError);
            }
            
            return result;
        }
    }
}