using System;
using PetaPoco;
using Newtonsoft.Json;
using SampleRest.Framework.Configuration;
using SampleRest.Framework.Const;
using SampleRest.Framework.DataConvertService;
using Demo.Api.Common.Enumerations;
using Demo.Api.Common.Errors.Constants;

namespace Demo.Api.Common.Entities.Biz
{
	public class ReturnT
	{
		[JsonIgnore]
		protected EnumDomain _returnDomain;

		public String ReturnDomain { get { return EnumConvert.ToDBCode<EnumDomain>(_returnDomain); } set { _returnDomain = EnumConvert.FromDBCode<EnumDomain>(value); } }
		[Column("RET_CODE")]
		public String ReturnCode { get; set; }
		[Column("RET_VALUE")]
		public String ReturnValue { get; set; }
		[Column("ERR_MSG")]
		private String OrgErrorMessage { get; set; }

		public String ErrorMessage
		{
			get
			{
				return ConstReturnCode.UnknownExceptionS.Equals(ReturnCode) ? "DB 오류가 발생했습니다." : this.OrgErrorMessage;
			}
			set
			{
				this.OrgErrorMessage = value;
			}
		}

		public String DebugMessage { get; set; }

		#region [생성자]
		public ReturnT()
			: this(EnumDomain.Unknown)
		{
		}

		public ReturnT(EnumDomain domain)
		{
			SetReturnCode(ConstCommonReturnCode.OK);

			_returnDomain = GetDomain(domain);
			this.DebugMessage = String.Empty;
		}

		public ReturnT(ReturnT request)
		{
			this._returnDomain = request._returnDomain;
			this.ReturnCode = request.ReturnCode;
			this.ReturnValue = request.ReturnValue;
			this.ErrorMessage = request.ErrorMessage;
			this.DebugMessage = String.Empty;
		}
		#endregion

		public void SetReturnCode(String returnCode)
		{
			ReturnCode = returnCode;
		}

		public EnumDomain GetDomain(EnumDomain domain)
		{
			EnumDomain returnData = domain;

			if (domain == EnumDomain.Unknown)
			{
				try
				{
					var systemList = FrameworkConfigSection.Instance.SystemItems;
					String domainString = systemList["Domain"];
					if (String.IsNullOrWhiteSpace(domainString) == false)
					{
						returnData = EnumConvert.FromDescription<EnumDomain>(domainString);
					}
				}
				catch
				{
					returnData = EnumDomain.Unknown;
				}
			}

			return returnData;
		}
	}
}