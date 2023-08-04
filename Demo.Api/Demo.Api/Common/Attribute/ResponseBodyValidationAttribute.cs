// using System;
// using System.Net.Http;
// using System.Web.Http.Filters;
// using System.Web.Http.Controllers;
// using Demo.Api.Common.Errors.Constants;
// using Demo.Api.Common.Errors.Utils;
//
// namespace Demo.Api.Common.Attribute
// {
//     public class RequestHeaderValidationAttribute : ActionFilterAttribute
//     {
//         private const string APPLICATION_JSON = "application/json";
//         private const string UTF_8 = "utf-8";
//         private const string CONTENT_TYPE = "Content-Type";
//         private const string CONTENT_ENCODING = "Content-Encoding";
//
//         public override void OnActionExecuting(HttpActionContext actionContext)
//         {
//             var request = actionContext.Request;
//             var headers = request.Content.Headers;
//
//             bool IsInvalidHeader = false;
//             string errorDetail = "";
//             if (headers.ContentType == null ||
//                 headers.ContentType.ToString().ToLower().Replace(" ", "") !=
//                 APPLICATION_JSON + ";" + "charset=" + UTF_8)
//             {
//                 if (headers.ContentType == null ||
//                     headers.ContentType.ToString().ToLower() != APPLICATION_JSON)
//                 {
//                     errorDetail = GetErrorDetail(CONTENT_TYPE, APPLICATION_JSON);
//                     IsInvalidHeader = true;
//                 }
//
//                 if (headers.ContentEncoding == null ||
//                     headers.ContentEncoding.ToString().ToLower() != UTF_8)
//                 {
//                     errorDetail = GetErrorDetail(CONTENT_ENCODING, UTF_8);
//                     IsInvalidHeader = true;
//                 }
//             }
//
//             if (IsInvalidHeader)
//             {
//                 ErrorCode errorCode = ErrorCode.InvalidHeader;
//                 if (String.IsNullOrWhiteSpace(errorDetail))
//                 {
//                     actionContext.Response = actionContext.Request.CreateResponse(
//                         ErrorCodeMapper.GetHttpStatusCode(errorCode),
//                         ErrorCodeMapper.GetErrors(errorCode)
//                     );
//                 }
//                 else
//                 {
//                     actionContext.Response = actionContext.Request.CreateResponse(
//                         ErrorCodeMapper.GetHttpStatusCode(errorCode),
//                         ErrorCodeMapper.GetErrors(errorCode, errorDetail)
//                     );
//                 }
//             }
//             else
//             {
//                 base.OnActionExecuting(actionContext);
//             }
//         }
//
//         private string GetErrorDetail(string InvalidHeaderField, string ValidHeaderValue)
//         {
//             return InvalidHeaderField + " is invalid. " + ValidHeaderValue + " value is required. ";
//         }
//     }
// }



using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Demo.Api.Common.Utils;
using System.Net.Http;
using Demo.Api.Common.Errors.Constants;
using Demo.Api.Common.Errors.Utils;

namespace Demo.Api.Common.Attribute
{
	public class RequestHeaderValidationAttribute : ActionFilterAttribute
	{
        private const string CLASS_NAME = "RequestHeaderValidationAttribute";

        private const string APPLICATION_JSON = "application/json";
		private const string UTF_8 = "utf-8";
		private const string CONTENT_TYPE = "Content-Type";
		private const string CONTENT_ENCODING = "Content-Encoding";

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			var request = actionContext.Request;
			var headers = request.Content.Headers;

			bool IsInvalidHeader = false;
			string errorDetail = "";
			
			/*
			if (headers.ContentType == null || headers.ContentType.ToString().ToLower().Replace(" ", "") != APPLICATION_JSON + ";" + "charset=" + UTF_8)
			{
				if (headers.ContentType == null ||
						headers.ContentType.ToString().ToLower() != APPLICATION_JSON)
				{
					errorDetail = GetErrorDetail(CONTENT_TYPE, APPLICATION_JSON);
					IsInvalidHeader = true;
				}

				if (headers.ContentEncoding == null ||
						headers.ContentEncoding.ToString().ToLower() != UTF_8)
				{
					errorDetail = GetErrorDetail(CONTENT_ENCODING, UTF_8);
					IsInvalidHeader = true;
				}
			}
			*/
			
			if (!"GET".Equals(request.Method.ToString().ToUpper()))
			{
				if (headers.ContentType == null || !headers.ContentType.ToString().ToLower().StartsWith(APPLICATION_JSON))
				{
				  errorDetail = GetErrorDetail(CONTENT_TYPE, APPLICATION_JSON);
				  IsInvalidHeader = true;
				}
			}

			if (IsInvalidHeader)
			{
				ErrorCode errorCode = ErrorCode.InvalidHeader;
				if (String.IsNullOrWhiteSpace(errorDetail))
				{
                    // log 남기기
                    // Logger.Error(actionContext.Request.RequestUri.AbsolutePath, new ArgumentException(ErrorCodeMapper.GetErrors(errorCode).Errors.Message));                    
                    //Logger.Error("[" + CLASS_NAME + "] Request parameters are not valid. ");

                    actionContext.Response = actionContext.Request.CreateResponse(
						ErrorCodeMapper.GetHttpStatusCode(errorCode),
						ErrorCodeMapper.GetErrors(errorCode)
					);
				}
				else
				{
                    // log 남기기
                    // Logger.Error(actionContext.Request.RequestUri.AbsolutePath, new ArgumentException(errorDetail));
                    // Logger.Error("[" + CLASS_NAME + "] " + errorDetail);

                    actionContext.Response = actionContext.Request.CreateResponse(
						ErrorCodeMapper.GetHttpStatusCode(errorCode),
						ErrorCodeMapper.GetErrors(errorCode, errorDetail)
					);
				}
			}
			else
			{
				base.OnActionExecuting(actionContext);
			}
		}

		private string GetErrorDetail(string InvalidHeaderField, string ValidHeaderValue)
		{
			return InvalidHeaderField + " is invalid. " + ValidHeaderValue + " value is required. ";
		}
	}
}