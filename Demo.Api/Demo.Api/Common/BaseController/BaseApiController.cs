using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demo.Api.Common.Errors.Utils;
using Demo.Api.Common.Errors.Constants;

namespace Demo.Api.Common.BaseController
{
    /// <summary>
    /// BaseApiController
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// SetResponse
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public HttpResponseMessage SetResponse(ErrorCode errorCode)
        {
            return Request.CreateResponse(ErrorCodeMapper.GetErrors(errorCode));
        }

        /// <summary>
        /// SetResponse
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorDetail"></param>
        /// <returns></returns>
        public HttpResponseMessage SetResponse(ErrorCode errorCode, object errorDetail)
        {
            return Request.CreateResponse(ErrorCodeMapper.GetErrors(errorCode, errorDetail));
        }

        /// <summary>
        /// SetResponse
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage SetResponse()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// httpStatusCode
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public HttpResponseMessage SetResponse(HttpStatusCode httpStatusCode)
        {
            return Request.CreateResponse(httpStatusCode);
        }

        /// <summary>
        /// SetResponse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseMessage"></param>
        /// <returns></returns>
        public HttpResponseMessage SetResponse<T>(T responseMessage)
        {
            return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
        }

        /// <summary>
        /// SetResponse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpStatusCode"></param>
        /// <param name="responseMessage"></param>
        /// <returns></returns>
        public HttpResponseMessage SetResponse<T>(HttpStatusCode httpStatusCode, T responseMessage)
        {
            return Request.CreateResponse(httpStatusCode, responseMessage);
        }
    }
}
