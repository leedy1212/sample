using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Demo.Api.Common.Errors.Utils;
using Demo.Api.Common.Errors.Constants;
using System.IO;
using Demo.Api.Common.Errors.Models;
using System.Diagnostics;

namespace Demo.Api.Common.Filters
{
	public class ErrorHttpMethodHandler : DelegatingHandler
	{
		private const string CLASS_NAME = "ErrorHttpMethodHandler";

		private static HttpStatusCode[] SuccessHttpStatusCodes = {
			HttpStatusCode.OK,
			HttpStatusCode.Created,
			HttpStatusCode.Accepted,
			HttpStatusCode.NonAuthoritativeInformation,
			HttpStatusCode.NoContent,
			HttpStatusCode.ResetContent,
			HttpStatusCode.PartialContent
		};
		private const string METHOD_NOT_ALLOWED_ERROR_DETAIL = "The requested resource does not support http method.";
		async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

			string errorMessage = null;
			try
			{
				Task<Dictionary<string, string>> readAsAsync = response.Content.ReadAsAsync<Dictionary<string, string>>();
				if(readAsAsync.Result.ContainsKey("Message"))
				{
					errorMessage = readAsAsync.Result["Message"];
				}
			}
			catch(AggregateException e) { }
			catch(ArgumentNullException) { }

			if (!SuccessHttpStatusCodes.Contains(response.StatusCode))
			{
				var errorsModel = response.Content.ReadAsAsync<ErrorsModel>().Result;
				if (errorsModel == null)
				{
					if (response.StatusCode == HttpStatusCode.MethodNotAllowed)
					{
                        // log 남기기
                        // Logger.Error(request.RequestUri.AbsolutePath, new AccessViolationException(errorMessage ?? METHOD_NOT_ALLOWED_ERROR_DETAIL));
                        //Logger.Error("[" + CLASS_NAME + "] " + errorMessage ?? METHOD_NOT_ALLOWED_ERROR_DETAIL);

                        ErrorCode errorCode = ErrorCode.MethodNowAllowed;
						return request.CreateResponse(
							ErrorCodeMapper.GetHttpStatusCode(errorCode),
							ErrorCodeMapper.GetErrors(errorCode, errorMessage ?? METHOD_NOT_ALLOWED_ERROR_DETAIL)
						);
					}
					else if (!String.IsNullOrWhiteSpace(errorMessage))
					{
                        // log 남기기
                        // Logger.Error(request.RequestUri.AbsolutePath, new AccessViolationException(errorMessage));

                        return request.CreateResponse(
							response.StatusCode,
							ErrorCodeMapper.GetErrorsForUndefinedMessage(ErrorCode.UnhandledFrameworkError, errorMessage)
						);
					}
				}
               
				return response;
			}

            return response;
		}
	}
}