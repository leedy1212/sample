using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SampleFx.Data.PetaPoco;
using SampleFx.Data.PetaPoco.Oracle;
using Demo.Api.Data.Constants;
using Demo.Api.BizDac.Common.Utils;
using Demo.Api.Data.Constants;
using Demo.Api.Data.Common.Results.Models;
using Demo.Api.Data.Entities.User;
using Demo.Api.Common.Constants;

namespace Demo.Api.BizDac.User
{
    //Data Access Class
    public class UserDac : OracleMicroDacBase
    {
        #region 사용자 조회
        /// <summary>
        /// 사용자 조회
        /// </summary>
        /// <returns></returns>
        public List<UserT> SelectUserAll()
        {
            // this.MicroDacHelper.CommandTimeout = Constants.Timeout;
            //
            // return this.MicroDacHelper.SelectMultipleEntities<UserT>(
            //     ConnectionStringName.ORACLE_READ
            //     , CommandType.Text
            //     , EasySqlResourceLoader.GetResource(GetType())
            // );
            
            // Test Data
            List<UserT> result = new List<UserT>();
            UserT data = new UserT();
            data.UserId = "test1";
            data.UserName = "Name1";
            data.UserAddress = "Address1";
            data.UserAge = "age";
            result.Add(data);

            UserT data2 = new UserT();
            data2.UserId = "test2";
            data2.UserName = "Name2";
            data2.UserAddress = "Address2";
            data2.UserAge = "age2";
            result.Add(data2);
           
            return result;
            
        }
        /// <summary>
        /// 사용자 조회
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserT SelectUserId(string userId)
        {
            // this.MicroDacHelper.CommandTimeout = Constants.Timeout;

            // List<UserT> list = this.MicroDacHelper.SelectMultipleEntities<UserT>(
            //     ConnectionStringName.ORACLE_READ
            //     , CommandType.Text
            //     , EasySqlResourceLoader.GetResource(GetType())
            //     , this.MicroDacHelper.CreateParameter("USER_ID", request.UserId)
            // );
            // return list;
            
            // Test Data
            UserT result = new UserT();
            result.UserId = userId;
            result.UserName = "UserName";
            result.UserAddress = "UserAddress";
            result.UserAge = "UserAge";

            return result;
        }

        /// <summary>
        /// 사용자 조회
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<UserT> SelectUser(UserReqeustM request)
        {
            // this.MicroDacHelper.CommandTimeout = Constants.Timeout;

            // List<UserT> list = this.MicroDacHelper.SelectMultipleEntities<UserT>(
            //     ConnectionStringName.ORACLE_READ
            //     , CommandType.Text
            //     , EasySqlResourceLoader.GetResource(GetType())
            //     , this.MicroDacHelper.CreateParameter("USER_ID", request.UserId)
            // );
            // return list;
            
            // Test Data
            List<UserT> result = new List<UserT>();
            UserT data = new UserT();
            data.UserId = request.UserId;
            data.UserName = request.UserName;
            data.UserAddress = request.UserAddress;
            data.UserAge = request.UserAge;
            result.Add(data);

            return result;
        }
        #endregion
        
        #region 사용자 추가
        /// <summary>
        /// 사용자 추가
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public void InsertUser(UserReqeustM request)
        {
            this.MicroDacHelper.CommandTimeout = Constants.Timeout;;
            this.MicroDacHelper.ExecuteNonQuery(
                ConnectionStringName.ORACLE_WRITE
                , CommandType.Text
                , EasySqlResourceLoader.GetResource(GetType())
                , this.MicroDacHelper.CreateParameter("USER_ID", request.UserId)
                , this.MicroDacHelper.CreateParameter("USER_NAME", request.UserName)
            );
        }
        #endregion
        
        #region 사용자 수정
        /// <summary>
        /// 사용자 수정
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public void UpdateUser(UserM request)
        {
            this.MicroDacHelper.CommandTimeout = Constants.Timeout;;
            this.MicroDacHelper.ExecuteNonQuery(
                ConnectionStringName.ORACLE_WRITE
                , CommandType.Text
                , EasySqlResourceLoader.GetResource(GetType())
                , this.MicroDacHelper.CreateParameter("USER_ID", request.UserId)
                , this.MicroDacHelper.CreateParameter("USER_NAME", request.UserName)
                , this.MicroDacHelper.CreateParameter("USER_ADDRESS", request.UserAddress)
                , this.MicroDacHelper.CreateParameter("USER_AGE", request.UserAge)
            );
        }
        #endregion        
    }
}