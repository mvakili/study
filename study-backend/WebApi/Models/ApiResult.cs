using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ApiResult
    {
        public ResultStatus ResultStatus { get; set; }
        public IEnumerable<string> Errors { get; set;}
    }

    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
    }
}