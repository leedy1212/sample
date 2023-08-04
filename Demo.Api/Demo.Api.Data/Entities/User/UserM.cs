using System;
using System.ComponentModel.DataAnnotations;
using Demo.Api.Common.Validations;
using PetaPoco;

namespace Demo.Api.Data.Entities.User
{
    // Request Model을 정의합니다
    public class UserReqeustM
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        [MaxLength(10)]
        // [RegularExpression(RegexConstants.PATTERN_USER_ID)]
        public string UserId { get; set; }
 
        /// <summary>
        /// 이름
        /// </summary>
        public string UserName { get; set; }
 
        /// <summary>
        /// 주소
        /// </summary>
        public string UserAddress { get; set; } = String.Empty;
 
        /// <summary>
        /// 나이
        /// </summary>
        [Range(0, 99)]
        public string UserAge { get; set; }
    }    
    
    public class UserM
    {
        /// <summary>
        /// 사용자ID
        /// </summary>
        [Column("USER_ID")]
        public string UserId { get; set; }

        /// <summary>
        /// 사용자이름
        /// </summary>
        [Column("USER_ID")] 
        public string UserName { get; set; }

        /// <summary>
        /// 주소
        /// </summary>
        [Column("USER_ID")] 
        public string UserAddress { get; set; }

        /// <summary>
        /// 나이
        /// </summary>
        [Column("USER_ID")] 
        public string UserAge { get; set; }
    }        
}