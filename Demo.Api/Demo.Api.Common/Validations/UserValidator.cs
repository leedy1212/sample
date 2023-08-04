using System;
using System.Text.RegularExpressions;

namespace Demo.Api.Common.Validations
{
    public class UserValidator : BaseParameterValidator // 새로운 Validator Class 생성 시 꼭 BaseParameterValidator를 상속
    {
        public static void IsValidUserId(string userId)
        {
            if(String.IsNullOrWhiteSpace(userId)) // Null or Empty 확인은 해당 Method를 사용 - String.IsNullOrWhiteSpace()
            {
                // 조건에 안 맞을 시에 해당 Method 호출
                //// CreateErrorResponse()
                //// 해당 메서드의 Parameter는 가능한 아래와 같이 전달
                //// nameof(userId) + BaseParameterValidator에 정의된 상수값
                CreateErrorResponse(nameof(userId) + ERROR_DETAIL_EMPTY);
            }
 
            if(userId.Length > 10)
            {
                CreateErrorResponse(nameof(userId) + ERROR_DETAIL_LENGTH);
            }
 
            string pattern = RegexConstants.PATTERN_USER_ID;
            if(!Regex.IsMatch(userId, pattern)) // Null이나 Length 체크 외에는 가능한 Regular Expression을 활용하여 사용하도록 합니다.
            {
                CreateErrorResponse(nameof(userId) + ERROR_DETAIL_FORMAT);
            }
        }
    }
}