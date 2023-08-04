using Demo.Api.Common.Enumerations;
using SampleRest.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Api.Common.Entities.Biz;

namespace Demo.Api.Common.Errors.Constants
{
	public class ConstReturnCode
	{
		public const string UnknownExceptionS = "998";
	}

	/// <summary> 
	/// 기본 Exception
	/// </summary>
	public class ExceptionS : ExceptionBase
	{
		public ReturnT Return { get; set; }
		private String _Message;
		public override String Message
		{
			get { return _Message; }
		}

		#region [생성자]
		public ExceptionS()
			: this(ConstReturnCode.UnknownExceptionS)
		{

		}

		public ExceptionS(String returnCode)
			: this(returnCode, String.Empty)
		{
		}

		public ExceptionS(String returnCode, String returnValue)
			: this(returnCode, returnValue, String.Empty)
		{
		}

		public ExceptionS(String returnCode, String returnValue, String errorMessage)
			: this(returnCode, returnValue, errorMessage, EnumDomain.Unknown)
		{
		}

		public ExceptionS(String returnCode, String errorMessage, System.Exception ex)
			: base(errorMessage, ex)
		{
			SetReturn(returnCode, String.Empty, errorMessage);

			SetErrorMessage(returnCode, errorMessage);
		}

		public ExceptionS(String returnCode, String returnValue, String errorMessage, EnumDomain domain)
		{
			SetReturn(returnCode, returnValue, errorMessage, domain);

			SetErrorMessage(returnCode, errorMessage);
		}

		public ExceptionS(ReturnT returnBase)
		{
			SetReturn(returnBase);

			SetErrorMessage(returnBase.ReturnCode, returnBase.ErrorMessage);
		}
		#endregion

		private void SetReturn(ReturnT returnBase)
		{
			if (String.IsNullOrWhiteSpace(returnBase.ErrorMessage) == true)
			{
				returnBase.ErrorMessage = this.GetType().Name;
			}

			this.Return = returnBase;
		}

		private void SetReturn(String returnCode, String returnValue, String errorMessage, EnumDomain domain = EnumDomain.Unknown)
		{
			SetReturn(new ReturnT(domain) { ReturnCode = returnCode, ReturnValue = returnValue, ErrorMessage = errorMessage });
		}

		private void SetErrorMessage(String returnCode, String errorMessage)
		{
			StackTrace st = new StackTrace();
			String stack = String.Empty;
			for (Int32 i = 1; i < 5 && i < st.FrameCount; i++)
			{
				stack += st.GetFrame(i).GetMethod().Name;
				stack += " < ";
			}

			_Message = this.Return.ReturnDomain.ToString() + " / " + returnCode + " / " + errorMessage + " / " + stack;
		}
	}
}