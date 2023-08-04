using PetaPoco;

namespace Demo.Api.Data.Entities.User
{
    // API Response Model을 정의합니다
    public class UserT
    {
        /// <summary>
        /// 사용자ID
        /// </summary>
        [Column("USER_ID")]
        public string UserId { get; set; }

        /// <summary>
        /// 사용자이름
        /// </summary>
        [Column("USER_NAME")] 
        public string UserName { get; set; }

        /// <summary>
        /// 주소
        /// </summary>
        [Column("USER_ADDRESS")] 
        public string UserAddress { get; set; }

        /// <summary>
        /// 나이
        /// </summary>
        [Column("USER_AGE")] 
        public string UserAge { get; set; }
    }    

    public class UserResponseT
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserAge { get; set; }
 
        public UserResponseT(UserT param)
        {
            this.UserId = param.UserId;
            this.UserName = param.UserName;
            this.UserAddress = param.UserAddress;
            this.UserAge = param.UserAge;
        }
    }
}