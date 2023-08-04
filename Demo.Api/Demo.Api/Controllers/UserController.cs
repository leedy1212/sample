using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Demo.Api.Data.Common.Results.Models;
using Demo.Api.Common.BaseController; 
using Demo.Api.Data.Entities.Sample;
using Demo.Api.Data.Entities.User;
using System.Web.Http.Description;
using Demo.Api.BizDac.User;
using Demo.Api.Common.Attribute;
using Demo.Api.Common.Validations;
using Demo.Api.Common.Exceptions;

// Controller Class 에서는
// 1. Parameter 유효성 검사
// 2. Biz 로직 호출
// 3. Response 값 반환
// 위 3가지의 작업만 수행하도록 하며, Business 로직은 Biz Class에서 수행
// Swagger에서 실제 Response Model을 보여주기 위해 각 메소드에는 ResponseType annotation을 사용하도록 합니다.
// Try Catch문은 사용하지 않는다. 오류 발생시 FilterConfig에 설정된 ErrorHttpMethodHandler에서 ErrorsModel에 담아서 오류값을 리턴해준다.
namespace Demo.Api.Controllers
{
    [RoutePrefix("user")]
    // [ApiExceptionFilter]
    public class UserController : BaseApiController
    {
        #region 사용자 정보 전체 조회
        /// <summary>
        /// 사용자 정보 전체 조회 
        /// </summary>
        /// <remarks>
        /// 사용자 정보를 조회합니다.
        /// 
        ///     Get /user/userAll
        ///
        /// </remarks>
        [HttpGet]
        [Route("userAll")]
        [ResponseType(typeof(ResponseListBasicModel<UserResponseT>))]
        public HttpResponseMessage GetuserAll()
        {
            // throw new Exception("에러 테스트");
            
            List<UserT> result = new UserBiz().GetUser();
            List<UserResponseT> response = new List<UserResponseT>();
                
            foreach (var item in result)
            {
                response.Add(new UserResponseT(item));
            }
            
            // 결과 반환
            return SetResponse(HttpStatusCode.OK, new ResponseListBasicModel<UserResponseT>(response));
        }
        #endregion

        #region 사용자 정보 조회
        /// <summary>
        /// 사용자 정보  조회
        /// </summary>
        /// <remarks>
        /// 사용자 정보를 조회합니다.
        /// 
        ///     GET /user/getUserId
        ///
        /// </remarks>
        [HttpGet]
        [Route("getUserId/{userId}")]
        [ResponseType(typeof(ResponseBasicModel<UserT>))]
        public HttpResponseMessage GetUserId(string userId)
        {
            UserValidator.IsValidUserId(userId);
            UserT response = new UserBiz().GetUserId(userId);

            // 결과 반환
            if (response != null)
            {
                return SetResponse(HttpStatusCode.OK, new ResponseBasicModel<UserT>(response));
            }
            else
            {
                return SetResponse(HttpStatusCode.NoContent, new ResponseBasicModel<UserT>(response));
            }
        }
        
        /// <summary>
        /// 사용자 정보  조회
        /// </summary>
        /// <remarks>
        /// 사용자 정보를 조회합니다.
        /// 
        ///     POST /user/getUsers
        ///
        /// </remarks>
        [HttpPost]
        [Route("getUsers")]
        [ResponseType(typeof(ResponseListBasicModel<SampleDataListT>))]
        public HttpResponseMessage GetUser([FromBody]UserReqeustM requst)
        {
            UserValidator.IsValidUserId(requst.UserId);
            List<UserT> result = new UserBiz().GetUser(requst);
            List<UserResponseT> response = new List<UserResponseT>();
            
            foreach (var item in result)
            {
                response.Add(new UserResponseT(item));
            }

            // 결과 반환
            if (response.Count > 0)
            {
                return SetResponse(HttpStatusCode.OK, new ResponseListBasicModel<UserResponseT>(response));
            }
            else
            {
                return SetResponse(HttpStatusCode.NoContent, new ResponseListBasicModel<UserResponseT>(response));
            }
        }
        #endregion
        

        #region 사용자 추가
        /// <summary>
        /// 사용자 추가
        /// </summary>
        /// <remarks>
        /// 사용자를 추가합니다.
        /// 
        ///     POST /user/addUser
        ///
        /// </remarks>
        [HttpPost]
        [Route("addUser")]
        [ResponseType(typeof(ResponseBasicModel<int>))]
        public HttpResponseMessage AddUser([FromBody]UserReqeustM requst)
        {
            new UserBiz().AddUser(requst);

            // 결과 반환
            return SetResponse(HttpStatusCode.Created, new ResponseBasicModel<int>(0));
        }
        #endregion

        #region 사용자 수정
        /// <summary>
        /// 사용자 수정
        /// </summary>
        /// <remarks>
        /// 사용자 정보를 수정합니다.
        /// 
        ///     PUT /user/setUser
        ///
        /// </remarks>        
        [HttpPut]
        [Route("setUser")]
        [SwaggerDefaultValue("user", "{\n" +
                                     "\"UserId\":\"111222\",\n" +
                                     "\"UserName\":\"홍길동\",\n" +
                                     "\"UserAddress\":\"Seoul, Korea\",\n" +
                                     "\"UserAge\":20\n" +
                                     "}")]       //  객체를 전달해야 할 경우
        [SwaggerRequestContentTypeAttribute(requestType: "application/json", Exclusive = true)]
        public HttpResponseMessage SetUser([FromBody]UserM requst)
        {
            new UserBiz().SetUser(requst);
 
            return SetResponse(HttpStatusCode.NoContent);
        }    
        #endregion
    }
}
