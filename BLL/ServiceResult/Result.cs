using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceResult
{
    public class Result
    {
        public bool Failed { get; }
        public string ErrorMessage { get; }

        //do we need this??
        public Result(bool failed, string errorMessage)
        {
            Failed = failed;
            ErrorMessage = errorMessage;
        }

        public static Result Success()
        {
            return new Result(false, string.Empty);
        }

        public static Result Fail(string errorMessage)
        {
            return new Result(true, errorMessage ?? string.Empty);
        }

        public static Result<TStatus> Success<TStatus>(TStatus status)
            where TStatus : IConvertible
        {
            return new Result<TStatus>(false, string.Empty, status);
        }

        public static Result<TStatus> Fail<TStatus>(TStatus status, string errorMessage = null)
            where TStatus : IConvertible
        {


            return new Result<TStatus>(true, errorMessage ?? string.Empty, status);
        }
    }

    public class Result<TStatus> : Result
        where TStatus : IConvertible
    {
        public TStatus Status { get;}

        public Result(bool failed, string errorMessage, TStatus status)
            : base (failed, errorMessage)
        {
            if (!typeof(TStatus).IsEnum)
            {
                throw new ArgumentException("TError must be an Enum.");
            }

            Status = status;
        }
    }
}
