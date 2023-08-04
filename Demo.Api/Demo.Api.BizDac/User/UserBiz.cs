using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleRest.Framework.DataAccessService;
using Demo.Api.Data.Common.Results.Models;
using Demo.Api.Data.Entities.User;
using SampleFx.EnterpriseServices;
using Demo.Api.Common.Exceptions;
using Demo.Api.Common.Utils;
using Demo.Api.Common.Errors.Constants;
using Demo.Api.Data.Entities.User;

/*
  실제로 모든 로직들이 이곳에서 작성합니다.
  OOP 설계 원칙**에 따라 Class와 Method는 항상 길어지지 않도록 주의하며,
  Method/Class로 나눌 여지가 있다면 주저말고 나누어 새로운 Method/Class를 작성하도록 합니다
  Biz Class는 단순히 Dac을 접근하기 위한 Class가 아니며, 로직만 존재하는 Class가 존재할 수도 있습니다.
 */
namespace Demo.Api.BizDac.User
{
    //Business(Service)
    public class UserBiz : BizBase
    {
        #region 사용자 조회
        /// <summary>
        /// 사용자 조회
        /// </summary>
        /// <returns></returns>
        [Transaction(TransactionOption.NotSupported)]
        public List<UserT> GetUser()
        {
            List<UserT> returnData = new UserDac().SelectUserAll();
            return returnData;
        }

        /// <summary>
        /// 사용자 조회
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // [Transaction(TransactionOption.NotSupported)]
        public UserT GetUserId(string userId)
        {
            UserT returnData = new UserDac().SelectUserId(userId);
            return returnData;
        }
        
        /// <summary>
        /// 사용자 조회
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // [Transaction(TransactionOption.NotSupported)]
        public List<UserT> GetUser(UserReqeustM request)
        {
            List<UserT> returnData = new UserDac().SelectUser(request);
            return returnData;
        }
        #endregion
        
        #region 사용자 추가
        /// <summary>
        /// 사용자 추가
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Transaction(TransactionOption.Supported)]
        public void AddUser(UserReqeustM request)
        {
            // UserT userT = new UserT();
            // PropertiesUtil.CopyProperties(UserM, userT);
            
            List<UserT> resultUsers = new UserDac().SelectUser(request);
            if (resultUsers.Count >= 1) throw new CustomBizException(ErrorCode.Duplicate);
            
            new UserDac().InsertUser(request);
        }
        #endregion
        
        #region 사용자 수정
        /// <summary>
        /// 사용자 추가
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Transaction(TransactionOption.Supported)]
        public void SetUser(UserM request)
        {
            new UserDac().UpdateUser(request);
        }
        #endregion        
    }
}