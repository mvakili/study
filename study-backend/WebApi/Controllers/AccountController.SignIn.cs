using System.Linq;
using System.Web;
using System.Web.Http;
using Models;
using Models.Api;
using WebApi.Handlers;

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

            return new DataJob()
            {
                Do = (context, result) =>
                {
                    var user =
                        context.Users.FirstOrDefault(u => u.UserName == input.Username && u.Password == input.Password);
                    if (user != null)
                    {
                        HttpContext.Current.Session["UserId"] = user.Id;
                    }
                    else
                    {
                        result.ResultStatus = ResultStatus.Failed;
                        result.Messages.Add(Models.Resources.Errors.UserNotFound);
                    }
                }
            }.Run();


        }
    }
}