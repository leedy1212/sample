using Demo.Api.Common.Enumerations;
using SampleRest.Framework.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Api.Common.Entities.Biz
{
    public class MicroResponseBase
    {
        protected ReturnT _resultBase;
        public ReturnT ResultBase { get { return _resultBase; } set { _resultBase = value; } }

        #region [ 생성자 ]
        public MicroResponseBase()
        {
            _resultBase = new ReturnT();
        }

        public MicroResponseBase(EnumDomain domain)
        {
            _resultBase = new ReturnT(domain);
        }

        public MicroResponseBase(ReturnT returnBase)
        {
            _resultBase = returnBase;
        }
        #endregion

        public void SetSuccess()
        {
            _resultBase.SetReturnCode(ConstCommonReturnCode.OK);
        }
    }
}