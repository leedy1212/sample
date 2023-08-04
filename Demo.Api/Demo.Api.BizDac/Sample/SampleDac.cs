using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SampleFx.Data.PetaPoco;
using SampleFx.Data.PetaPoco.Oracle;
using Demo.Api.Data.Entities.Sample;
using Demo.Api.Data.Constants;
using Demo.Api.BizDac.Common.Utils;
using Demo.Api.Data.Constants;
using Demo.Api.Data.Common.Results.Models;
using Demo.Api.Data.Entities.Sample;
using Demo.Api.Common.Constants;

namespace Demo.Api.BizDac.Sample
{
	public class SampleDac : OracleMicroDacBase
	{
		#region 사용자
		/// <summary>
		/// 사용자 조회
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public List<SampleDataListT> SelectSampleDataList(SampleRequestM request)
		{
			// this.MicroDacHelper.CommandTimeout = 60;
			this.MicroDacHelper.CommandTimeout = Constants.Timeout;
			
			// List<SampleDataListT> list = this.MicroDacHelper.SelectMultipleEntities<SampleDataListT>(
			// 	ConnectionStringName.ORACLE_READ
			//     , CommandType.Text
			//     , EasySqlResourceLoader.GetResource(GetType())
			// 	, this.MicroDacHelper.CreateParameter("USER_ID", request.taskCode)
			// );
			// return list;
			
			return this.MicroDacHelper.SelectMultipleEntities<SampleDataListT>(
				  ConnectionStringName.ORACLE_READ
				, CommandType.Text
				, EasySqlResourceLoader.GetResource(GetType())
				// , this.MicroDacHelper.CreateParameter("USER_ID", request.taskCode)
				);			
		}
		#endregion
		
		public SampleDataListT SelectSampleList(SempleListRequstM request)
		{
			string sql = EasySqlResourceLoader.GetResource(GetType());
			// string sql = ResourceLoader.GetString(new SqlResourceLookup(typeof(SampleDac), "SelectSampleDataList"));
			
			this.MicroDacHelper.CommandTimeout = Constants.Timeout;
			return this.MicroDacHelper.SelectSingleEntity<SampleDataListT>(
				ConnectionStringName.ORACLE_READ
				, CommandType.Text
				, sql
				// , this.MicroDacHelper.CreateParameter("USER_ID", request.fromDate)
			);
		}

		
	}
}