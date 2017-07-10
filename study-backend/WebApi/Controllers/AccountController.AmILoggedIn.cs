using System.Web;
using System.Web.Http;
using Models;
using Models.Api;
using WebApi.Handlers;

namespace WebApi.Controllers
{
    public partial class AccountController
    {

        [HttpPost]
        public ApiResult<bool> AmILoggedIn()
        {

            return new Job<bool>
            {
                Do = result =>
                {
                    result.Data = HttpContext.Current.Session?["UserId"] != null;
                }
            }.Run();

        }
    }
}