using System.Web;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public partial class AccountController
    {

        [HttpPost]
        public  ApiResult<bool> AmILoggedIn()
        {
            var result = new ApiResult<bool>();

            try
            {

                if (HttpContext.Current.Session?["UserId"] != null)
                {
                    result.Data = true;
                }
                else
                {
                    result.Data = false;
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