using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using Demo.Api.Common.Attributes;
using Demo.Api.Common.Errors.Attributes;
using Demo.Api.Common.Errors.Constants;
using Demo.Api.Common.Errors.Models;

namespace Demo.Api.Common.Errors.Utils
{
	public static class ErrorCodeMapper
	{
		public static ErrorsModel GetErrors(ErrorCode errorCode)
		{
			ErrorModel error = new ErrorModel((int)errorCode, errorCode.ToString(), GetErrorMessage(errorCode));
			ErrorsModel errors = new ErrorsModel(error);

			return errors;
		}

		public static ErrorsModel GetErrors(ErrorCode errorCode, object errorDetail)
		{
			ErrorModel error = new ErrorModel((int)errorCode, errorCode.ToString(), GetErrorMessage(errorCode));
			if(errorDetail != null)
				error.Details = errorDetail;
			ErrorsModel errors = new ErrorsModel(error);

			return errors;
		}

		public static ErrorsModel GetErrorsForUndefinedMessage(ErrorCode errorCode, string errorMessage)
		{
			ErrorModel error = new ErrorModel((int)errorCode, errorCode.ToString(), errorMessage);
			ErrorsModel errors = new ErrorsModel(error);

			return errors;
		}

		private static string GetErrorMessage(ErrorCode errorCode)
		{
			return GetEnumErrorMessage<ErrorCode>(errorCode);
		}

		public static HttpStatusCode GetHttpStatusCode(ErrorCode errorCode)
		{
			return GetEnumHttpStatusCode<ErrorCode>(errorCode);
		}

		private static string GetEnumErrorMessage<T>(T value)
		{
			Type type = value.GetType();
			FieldInfo fieldInfo = type.GetField(value.ToString());
			
			ErrorMessageAttribute[] values = fieldInfo.GetCustomAttributes(typeof(ErrorMessageAttribute), false) as ErrorMessageAttribute[];
			string ResultErrorMessage = "";
			if (values.Length > 0)
			{
				ResultErrorMessage = values[0].ErrorMessage;
			}

			return ResultErrorMessage;
		}

		private static HttpStatusCode GetEnumHttpStatusCode<T>(T value)
		{
			Type type = value.GetType();
			FieldInfo fieldInfo = type.GetField(value.ToString());
			
			HttpStatusCodeAttribute[] values = fieldInfo.GetCustomAttributes(typeof(HttpStatusCodeAttribute), false) as HttpStatusCodeAttribute[];
			HttpStatusCode resultHttpStatusCode = HttpStatusCode.InternalServerError;
			if (values.Length > 0)
			{
				resultHttpStatusCode = values[0].HttpStatusCode;
			}

			return resultHttpStatusCode;
		}
	}
}
