// using System;
// using System.Linq;
// using System.Web.Http.Filters;
// using System.Web.Http.Controllers;
// using System.Net.Http;
// using Demo.Api.Common.Errors.Constants;
// using System.Web.Http.ModelBinding;
// using Demo.Api.Common.Errors.Utils;
//
// namespace Demo.Api.Common.Attribute
// {
//     public class RequestBodyValidationAttribute : ActionFilterAttribute
//     {
//         private const string CLASS_NAME = "RequestBodyValidationAttribute";
//
//         private readonly HttpMethod[] NotAllowedBodyNullMethods =
//         {
//             HttpMethod.Post,
//             HttpMethod.Put
//         };
//         
//         ErrorCode errorCode = ErrorCode.InvalidParameter;
//         
//         public override void OnActionExecuting(HttpActionContext actionContext)
//         {
//             if (ValidateRequestBodyEmpty(actionContext))
//             {
//                 actionContext.Response = actionContext.Request.CreateResponse(
//                     ErrorCodeMapper.GetHttpStatusCode(ErrorCode.InvalidParameterEmpty),
//                     ErrorCodeMapper.GetErrors(ErrorCode.InvalidParameterEmpty) 
//                 );
//         
//                 // Logger.Error("[" + CLASS_NAME + "] The request failed because it contained nothing.");              
//             }
//             else if (!actionContext.ModelState.IsValid)
//             {
//                 object errorDetail = GetRequestBodyErrorDetail(actionContext.ModelState);
//                 actionContext.Response = actionContext.Request.CreateResponse(
//                     ErrorCodeMapper.GetHttpStatusCode(errorCode),
//                     ErrorCodeMapper.GetErrors(errorCode, errorDetail)
//                 );
//         
//                 // Logger.Error("[" + CLASS_NAME + "] Request parameters are not valid. " + errorDetail);
//             }
//         }
//         
//         private bool ValidateRequestBodyEmpty(HttpActionContext actionContext)
//         {
//             if (NotAllowedBodyNullMethods.Contains(actionContext.Request.Method))
//             {
//                 // Logger.Info("[" + CLASS_NAME + "] Arguments count is " + actionContext.ActionArguments.Count);
//                 if (actionContext.ActionArguments.Count == 0)
//                 {
//                     return true;
//                 }
//             }
//         
//             return false;
//         }
//         
//         private object GetRequestBodyErrorDetail(ModelStateDictionary modelState)
//         {
//             var errorMessages = modelState
//                 .Where(e => e.Value.Errors.Count > 0)
//                 .ToDictionary(
//                     kvp => kvp.Key,
//                     kvp => kvp.Value.Errors.Select(e => GetErrorMessage(e)).ToArray()
//                 );
//         
//             return errorMessages;
//         }
//         
//         private string GetErrorMessage(ModelError modelError)
//         {
//             string errorMessage = "";
//             if (modelError.Exception != null
//                 && !String.IsNullOrWhiteSpace(modelError.Exception.Message ?? ""))
//             {
//                 errorMessage = modelError.Exception.Message;
//                 errorCode = ErrorCode.InvalidParameterJsonFormat;
//             }
//             else if (!String.IsNullOrWhiteSpace(modelError.ErrorMessage ?? ""))
//             {
//                 errorMessage = modelError.ErrorMessage;
//                 errorCode = ErrorCode.InvalidParameter; 
//             }
//         
//             return errorMessage;
//         }
//     }
// }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Demo.Api.Common.Utils;
using System.Net.Http;
using Demo.Api.Common.Errors.Constants;
using Demo.Api.Common.Errors.Utils;
using System.Web.Http.ModelBinding;
using SampleFx.Diagnostics;
using System.IO;
using System.Diagnostics;

namespace Demo.Api.Common.Attribute
{
	public class RequestBodyValidationAttribute : ActionFilterAttribute
	{
		private readonly HttpMethod[] NotAllowedBodyNullMethods = {
			HttpMethod.Post,
			HttpMethod.Put
		};

		ErrorCode errorCode = ErrorCode.InvalidParameter;

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if(ValidateRequestBodyEmpty(actionContext))
			{
                // log 남기기
                // Logger.Error(actionContext.Request.RequestUri.AbsolutePath, new ArgumentNullException(Newtonsoft.Json.JsonConvert.SerializeObject("The request failed because it contained nothing.")));

                actionContext.Response = actionContext.Request.CreateResponse(
					ErrorCodeMapper.GetHttpStatusCode(ErrorCode.InvalidParameterEmpty),
					ErrorCodeMapper.GetErrors(ErrorCode.InvalidParameterEmpty)
				);
			}
			else if(!actionContext.ModelState.IsValid)
			{
                Dictionary<string, string[]> errorDetail = GetRequestBodyErrorDetail(actionContext.ModelState);
               
                // log 남기기
                // Logger.Error(actionContext.Request.RequestUri.AbsolutePath, new ArgumentException(Newtonsoft.Json.JsonConvert.SerializeObject(errorDetail)));
               
                actionContext.Response = actionContext.Request.CreateResponse(
					ErrorCodeMapper.GetHttpStatusCode(errorCode),
					ErrorCodeMapper.GetErrors(errorCode, errorDetail)
				);
            }
		}

		private bool ValidateRequestBodyEmpty(HttpActionContext actionContext)
		{
			if (NotAllowedBodyNullMethods.Contains(actionContext.Request.Method))
			{
				if (actionContext.ActionArguments.Count == 0)
				{
					return true;
				}
			}

			return false;
		}

		private Dictionary<string,string[]> GetRequestBodyErrorDetail(ModelStateDictionary modelState)
		{
			var errorMessages = modelState
					.Where(e => e.Value.Errors.Count > 0)
					.ToDictionary(
				kvp => kvp.Key,
				kvp => kvp.Value.Errors.Select(e => GetErrorMessage(e)).ToArray()
			);
			
			return errorMessages;
		}

		private string GetErrorMessage(ModelError modelError)
		{
			string errorMessage = "";
			if (modelError.Exception != null
				&& !String.IsNullOrWhiteSpace(modelError.Exception.Message ?? ""))
			{
				errorMessage = modelError.Exception.Message;
				errorCode = ErrorCode.InvalidParameterJsonFormat;
			}
			else if (!String.IsNullOrWhiteSpace(modelError.ErrorMessage ?? ""))
			{
				errorMessage = modelError.ErrorMessage;
				errorCode = ErrorCode.InvalidParameter;
			}
			return errorMessage;
		}
	}
}