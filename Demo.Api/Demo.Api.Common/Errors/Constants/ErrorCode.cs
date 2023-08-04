using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Demo.Api.Common.Attributes;
using Demo.Api.Common.Errors.Attributes;

namespace Demo.Api.Common.Errors.Constants
{
	public enum ErrorCode
	{
		[HttpStatusCodeAttribute(HttpStatusCode.OK)]
		OK = 0,

		[HttpStatusCodeAttribute(HttpStatusCode.OK)]
		[ErrorMessageAttribute("Not found data. But request is ok.")]
		NoData = 1,

		[HttpStatusCodeAttribute(HttpStatusCode.InternalServerError)]
		[ErrorMessageAttribute("The request failed due to an internal error.")]
		UnhandledFrameworkError = 301,

		[HttpStatusCodeAttribute(HttpStatusCode.MethodNotAllowed)]
		[ErrorMessageAttribute("The HTTP method associated with the request is not supported.")]
		MethodNowAllowed = 302,

		[HttpStatusCodeAttribute(HttpStatusCode.BadRequest)]
		[ErrorMessageAttribute("The request failed because it contained an invalid header.")]
		InvalidHeader = 401,

		[HttpStatusCodeAttribute(HttpStatusCode.BadRequest)]
		[ErrorMessageAttribute("The request failed because it contained an invalid parameter or parameter value.")]
		InvalidParameter = 411,

		[HttpStatusCodeAttribute(HttpStatusCode.BadRequest)]
		[ErrorMessageAttribute("The request failed because it contained an invalid JSON format.")]
		InvalidParameterJsonFormat = 412,

		[HttpStatusCodeAttribute(HttpStatusCode.BadRequest)]
		[ErrorMessageAttribute("The request failed because it contained nothing.")]
		InvalidParameterEmpty = 413,

		
		[HttpStatusCodeAttribute(HttpStatusCode.NotFound)]
		[ErrorMessageAttribute("The requested operation failed because a resource associated with the request could not be found.")]
		NotFound = 501,

		[HttpStatusCodeAttribute(HttpStatusCode.Conflict)]
		[ErrorMessageAttribute("The requested operation failed because it tried to create a resource that already exists.")]
		Duplicate = 521,
		
		[HttpStatusCodeAttribute(HttpStatusCode.InternalServerError)]
		[ErrorMessageAttribute("SQL Business error occurred.")]
		SqlBusinessError = 522,

		[HttpStatusCodeAttribute(HttpStatusCode.ServiceUnavailable)]
		[ErrorMessageAttribute("SQL server error occurred.")]
		SqlServerError = 701,

		[HttpStatusCodeAttribute(HttpStatusCode.ServiceUnavailable)]
		[ErrorMessageAttribute("Mail server error occurred.")]
		MailServerError = 702,

		[HttpStatusCodeAttribute(HttpStatusCode.InternalServerError)]
		[ErrorMessageAttribute("The request failed due to an internal error.")]
		InternalError = 999,

	}
}