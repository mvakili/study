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
        public class PostModel
        {
            public int i { get; set; }
            public int j { get; set; }
        }

        [HttpPost]
        public ApiResult<int> Post([FromBody] PostModel obj)
        {
            return new ApiResult<int>
            {
                ResultStatus = ResultStatus.Successful,
                Data = obj.i * obj.j
            };
        }
    }
}