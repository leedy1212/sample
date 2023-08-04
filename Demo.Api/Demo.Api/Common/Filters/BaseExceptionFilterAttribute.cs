using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Demo.Api.Common.Errors.Constants;
using Demo.Api.Common.Errors.Utils;
using Demo.Api.Common.Exceptions;
using Demo.Api.Common.Utils;
using SampleFx;
using SampleFx.Diagnostics;
using System.Security;

namespace Demo.Api.Common.Filters
{
    [ComponentType(ComponentType.FrameworkComponent)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    [TraceCategory(TraceCategory.NAME_ENTERPRISESERVICES)]
    public class BaseExceptionFilterAttribute : ExceptionFilterAttribute
	{
		private const string DEFAULT_ERROR_DETAIL = "Exception message does not exist";

		private const string CLASS_NAME = "BaseExceptionFilterAttribute";

		public override void OnException(HttpActionExecutedContext context)
		{
			ErrorCode errorCode = ErrorCode.InternalError;
			string errorDetail = null;

			if (context.Exception is CustomBizException)
			{
				errorCode = (ErrorCode)Enum.Parse(typeof(ErrorCode), context.Exception.Source);
				if (context.Exception.Message != null)
				{
                    errorDetail = context.Exception.Message;
                    //errorDetail = context.Exception.Source;
				}
				else {
					errorDetail = context.Exception.Source;
				}
			}
            else if (context.Exception is SecurityException)
            {
                errorCode = ErrorCode.InvalidHeader;
                errorDetail = context.Exception.Message ?? DEFAULT_ERROR_DETAIL;
            }
			else if (context.Exception is HttpResponseException)
			{
				errorCode = ErrorCode.InvalidHeader;
				errorDetail = context.Exception.Message ?? DEFAULT_ERROR_DETAIL;
			}
			else if (context.Exception is SqlException)
			{
				errorCode = ErrorCode.SqlServerError;
				errorDetail = context.Exception.Message ?? DEFAULT_ERROR_DETAIL;
			}
			else if (context.Exception is Exception)
			{
				errorCode = ErrorCode.InternalError;
				errorDetail = context.Exception.Message ?? DEFAULT_ERROR_DETAIL;
			}
           
            // Exception Trace Log
            // Logger.Error(context.Exception);

            context.Response = context.Request.CreateResponse(
					ErrorCodeMapper.GetHttpStatusCode(errorCode),
					ErrorCodeMapper.GetErrors(errorCode, errorDetail)
				);
		}
	}
}