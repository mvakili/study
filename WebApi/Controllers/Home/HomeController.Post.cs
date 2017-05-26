using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers.Home
{
	public partial class HomeController
	{
        [HttpPost]
        public ApiResult<int> Post([FromBody] int i)
        {
            return new ApiResult<int>
            {
                ResultStatus = ResultStatus.Successful,
                Data = i
            };
        }
    }
}