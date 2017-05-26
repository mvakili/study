using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ApiResult
    {
        public ResultStatus ResultStatus { get; set; } = ResultStatus.Successful;
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
    }
}