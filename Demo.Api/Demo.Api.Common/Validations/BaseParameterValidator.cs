using Demo.Api.Common.Exceptions;
using Demo.Api.Common.Errors.Constants;

namespace Demo.Api.Common.Validations
{
    public class BaseParameterValidator
    {
        protected static string ERROR_DETAIL_EMPTY = " must not be empty.";
        protected static string ERROR_DETAIL_LENGTH = " is invalid length.";
        protected static string ERROR_DETAIL_RANGE = " is invalid range.";
        protected static string ERROR_DETAIL_FORMAT = " is invalid format.";

        protected static void CreateErrorResponse()
        {
            throw new CustomBizException(ErrorCode.InvalidParameter);
        }

        protected static void CreateErrorResponse(string errorDetail)
        {
            throw new CustomBizException(ErrorCode.InvalidParameter, errorDetail);
        }

    }
}