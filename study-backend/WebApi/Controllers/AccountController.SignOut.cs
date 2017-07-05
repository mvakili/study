using System.Web;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public partial class AccountController
    {

        [HttpPost]
        public  ApiResult SignOut()
        {
            var result = new ApiResult();

            try
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    HttpContext.Current.Session.Remove("UserId");
                }
                return result;
            }
            catch
            {
                result.Messages.Clear();
                result.ResultStatus = ResultStatus.Thrown;
                return result;
            }
        }
    }
}