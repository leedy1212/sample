using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Api.Common.Errors.Models;

namespace Demo.Api.Data.Common.Results.Models
{
    /// <summary>
    /// 일반 결과 반환 기본 모델  
    /// </summary>
    public class ResponseBasicModel<T>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="returnValue"></param>
        public ResponseBasicModel(T returnValue)
        {
            ReturnValue = returnValue;
        }

        /// <summary>
        /// 결과 데이터
        /// </summary>
        public T ReturnValue { get; set; }

        /// <summary>
        /// 오류결과
        /// </summary>
        public ErrorModel Errors { get; set; }
    }

}
