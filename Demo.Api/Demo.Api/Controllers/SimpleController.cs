using SampleRest.Api.Server.Filter;
using SampleRest.Framework.Data.Enum;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Demo.Api.Data.Common.Results.Models;
using Demo.Api.Data.Entities;
using Demo.Api.Common.BaseController;

namespace Demo.Api.Controllers
{
    [RoutePrefix("api/simple")]
    // [ApiTracingFilter(EnumServiceType.Test3)]
    [ApiExceptionFilter]
    public class SimpleController : BaseApiController
    {
        /// <summary>
        /// 사용자 정보  조회
        /// </summary>
        /// <remarks>
        /// 사용자 정보를 조회합니다.
        /// 
        ///     GET /api/simple/users?userId={userId}
        ///
        /// </remarks>
        [HttpGet]
        [Route("users/{userId}")]
        public HttpResponseMessage GetUser(string userId)
        {
            try
            {
                // Test Data
                List<SampleListResponseT> response = new List<SampleListResponseT>();
                SampleListResponseT dataList1 = new SampleListResponseT();
                dataList1.CustNo = 1;
                dataList1.Name = "Name";
                dataList1.Age = 1;
                dataList1.Address = "Address";
                response.Add(dataList1);
            
                SampleListResponseT dataList2 = new SampleListResponseT();
                dataList2.CustNo = 2;
                dataList2.Name = "Name";
                dataList2.Age = 2;
                dataList2.Address = "Address";
                response.Add(dataList2);             
                
                if (response.Count > 0)
                {
                    return SetResponse(HttpStatusCode.OK, new ResponseListBasicModel<SampleListResponseT>(response));
                }
                else
                {
                    return SetResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return SetResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        
        [HttpGet]
        [Route("")]
        public TestEntity Get()
        {
            return new TestEntity {
                PropInt = 100,
                PropString = "Http GET Test",
                PropDateTime = DateTime.Now
            };
        }
        
        [HttpGet]
        [Route("{delay:int}")]
        public TestEntity GetWithDelay(int delay)
        {
            System.Threading.Thread.Sleep(delay);

            return new TestEntity
            {
                PropInt = 100,
                PropString = string.Format("Http GET Test with delay({0})", delay),
                PropDateTime = DateTime.Now
            };
        }

        [HttpPost]
        [Route("")]
        public TestEntity Post([FromBody]TestEntity req)
        {
            if(req != null)
            {
                return new TestEntity{
                    PropInt = req.PropInt,
                    PropString = string.Format("Echo: {0} - Http POST Test", req.PropString),
                    PropDateTime = DateTime.Now
                };
            }
            else
            {
                throw new ArgumentNullException("Request input is null");
            }
        }
    }

    public class TestEntity 
    {
        public string PropString { get; set; }
        public int PropInt { get; set; }
        public DateTime PropDateTime { get; set; }
    }
    
    // API Response Model을 정의합니다
    public class SampleListResponseT
    {
        /// <summary>
        /// 고객번호
        /// </summary>
        public long CustNo { get; set; }

        /// <summary>
        /// 고객이름
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 나이
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 주소
        /// </summary>
        public string Address { get; set; }
    }


}
