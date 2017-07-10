﻿using System.Collections.Generic;
namespace Models.Api
{
    public class ApiResult
    {
        public ResultStatus ResultStatus { get; set; } = ResultStatus.Successful;
        public List<string> Messages { get; set; } = new List<string>();
    }

    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
    }
}