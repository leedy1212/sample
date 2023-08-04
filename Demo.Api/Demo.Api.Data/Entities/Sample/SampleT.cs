using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Api.Data.Entities.Sample
{
    // API Response Model을 정의합니다
    public class SampleDataListT
    {
        /// <summary>
        /// 고객번호
        /// </summary>
        public long CustNo { get; set; }

        /// <summary>
        /// 고객이름
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 나이
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 주소
        /// </summary>
        public string Address { get; set; }
    }
}