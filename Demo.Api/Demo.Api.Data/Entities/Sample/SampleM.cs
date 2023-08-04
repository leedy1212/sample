using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Demo.Api.Data.Entities.Sample
{
    // Request Model을 정의합니다
    public class SempleListRequstM
    {
        [Required]
        public DateTime fromDate { get; set; }

        [Required]
        public DateTime toDate { get; set; }

        public String sumType { get; set; }
    }


    /// <summary>
    /// 샘플 조회 요청 인터페이스
    /// </summary>
    public class SampleRequestI
    {
        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required]
        public String userId { get; set; }
        /// <summary>
        /// 시작일
        /// </summary>        
        public DateTime startDate { get; set; }
        /// <summary>
        /// 종료일
        /// </summary>
        public DateTime endDate { get; set; }
        /// <summary>
        /// 필터
        /// </summary>
        [MaxLength(10)]
        public String filter { get; set; }
    }

    /// <summary>
    /// 샘플 조회 요청 인터페이스
    /// </summary>
    public class SampleRequestM
    {
        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required]
        public String taskCode { get; set; }
    }

}