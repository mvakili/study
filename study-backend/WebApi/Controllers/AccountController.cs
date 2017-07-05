using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public partial class AccountController : ApiController
    {





    }
}
