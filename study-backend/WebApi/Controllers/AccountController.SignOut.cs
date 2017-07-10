using System.Web;
using System.Web.Http;
using Models.Api;
using WebApi.Handlers;

namespace WebApi.Controllers
{
    public partial class AccountController
    {

        [HttpPost]
        public  ApiResult SignOut()
        {
            return new DataJob()
            {
                Do = (context, result) =>
                {
                    if (HttpContext.Current.Session["UserId"] != null)
                    {
                        HttpContext.Current.Session.Remove("UserId");
                    }

                }
            }.Run();
        }
    }
}