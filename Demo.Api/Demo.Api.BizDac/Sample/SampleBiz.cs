using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleRest.Framework.DataAccessService;
using Demo.Api.Data.Common.Results.Models;
using Demo.Api.Data.Entities.Sample;
using SampleFx.EnterpriseServices;

namespace Demo.Api.BizDac.Sample
{
    public class SampleBiz : BizBase
    {
        /// <summary>
        /// 사용자 조회
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Transaction(TransactionOption.NotSupported)]        
        public SampleDataListT SelectSampleList(SempleListRequstM request)
        {
            SampleDataListT returnData = new SampleDac().SelectSampleList(request);
            return returnData;
        }

        /// <summary>
        /// 데이터 조회
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Transaction(TransactionOption.Disabled)]
        public List<SampleDataListT> GetSampleDataList(SampleRequestM request)
        {
            List<SampleDataListT> response = new SampleDac().SelectSampleDataList(request);
            return response;
        }

    }
}