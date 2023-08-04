using System;
using Demo.Api.Common.Errors.Constants;

namespace Demo.Api.Common.Exceptions
{
    public class CustomBizException : System.Exception
    {
        public CustomBizException(ErrorCode errorCode)
        {
            Source = errorCode.ToString();
        }
 
        public CustomBizException(ErrorCode errorCode, string errorDetail) :
            base(errorDetail)
        {
            Source = errorCode.ToString();
        }
 
        public override string Source { get; set; }
    }
}