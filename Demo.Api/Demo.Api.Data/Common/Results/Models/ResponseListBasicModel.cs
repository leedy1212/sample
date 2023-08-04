using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Demo.Api.Common.Errors.Models;

namespace Demo.Api.Data.Common.Results.Models
{
    public class ResponseListBasicModel<T>
    {
        /// <summary>
        /// 리스트 결과 반환 기본 모델  
        /// </summary>
        /// <param name="returnValue"></param>
        public ResponseListBasicModel(List<T> returnValue)
        {
            ReturnValue = returnValue;
            Count = returnValue.Count;
        }

        /// <summary>
        /// 리스트 결과 반환 기본 모델
        /// </summary>
        /// <param name="returnValue"></param>
        public ResponseListBasicModel(List<T> returnValue, int totalCount)
        {
            ReturnValue = returnValue;
            Count = totalCount;
        }

        /// <summary>
        /// 리스트 결과
        /// </summary>
        public List<T> ReturnValue { get; set; }

        /// <summary>
        /// 리스트 결과 갯수
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 오류결과
        /// </summary>
        public ErrorModel Errors { get; set; }
    }
}