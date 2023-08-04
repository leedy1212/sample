using System;
using Demo.Api.Common.Errors.Models;

namespace Demo.Api.Data.Common.Results.Models
{
    public class ResponseSimpleModel
    {
        public ResponseSimpleModel()
        {
            Errors = new ErrorModel();
        }
        /// <summary>
        /// 오류결과
        /// </summary>
        public ErrorModel Errors { get; set; }
    }

    /// <summary>
    /// Return 메시지
    /// </summary>
    public class SimpleResultT
    {
        /// <summary>
        /// 공통메시지
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 공통메시지
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// 건수
        /// </summary>
        public Int64 totalCount { get; set; }
    }
}
