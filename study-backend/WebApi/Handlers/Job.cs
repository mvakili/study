using System;
using System.Transactions;
using DAL;
using Models;
using Models.Api;

namespace WebApi.Handlers
{

    public class Job<T>
    {
        public delegate void Work(ApiResult<T> result);

        public Work Do { get; set; }

        public ApiResult<T> Run()
        {
            var result = new ApiResult<T> {ResultStatus = ResultStatus.Successful};


            try
            {
                Do(result);
            }
            catch (Exception)
            {
                result.Messages.Clear();
                result.ResultStatus = ResultStatus.Thrown;
            }

            return result;
        }
    }

    public class Job
    {
        public delegate void Work( ApiResult result);

        public Work Do { get; set; }

        public ApiResult Run()
        {
            var result = new ApiResult {ResultStatus = ResultStatus.Successful};
            try
            {
                Do( result);
            }
            catch (Exception)
            {
                result.Messages.Clear();
                result.ResultStatus = ResultStatus.Thrown;
            }

            return result;
        }
    }
    public class DataJob<T>
    {
        public delegate void Work(StudyContext context,  ApiResult<T> result);


        public Work Do { get; set; }

        public ApiResult<T> Run()
        {
            var result = new ApiResult<T> {ResultStatus = ResultStatus.Successful};


            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    var context = new StudyContext();
                    Do(context,  result);
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                result.Messages.Clear();
                result.ResultStatus = ResultStatus.Thrown;
            }

            return result;
        }
    }

    public class DataJob
    {
        public delegate void Work(StudyContext context, ApiResult result);

        public Work Do { get; set; }

        public ApiResult Run()
        {
            var result = new ApiResult {ResultStatus = ResultStatus.Successful};


            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    var context = new StudyContext();
                    Do(context, result);
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                result.Messages.Clear();
                result.ResultStatus = ResultStatus.Thrown;
            }

            return result;
        }
    }


}
