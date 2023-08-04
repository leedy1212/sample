using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Demo.Api.Common.Filters
{
    public class ExtendedHeaderHandler : DelegatingHandler
    {
        private const string CLASS_NAME = "ExtendedHeaderHandler";

        private readonly string[] AllowedMethods = {
            HttpMethod.Put.ToString(),
            HttpMethod.Delete.ToString()
        };
        private const string MethodOverrideHeader = "X-HTTP-Method-Override";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post && request.Headers.Contains(MethodOverrideHeader))
            {
                // Override가 허용되는 요청인지 확인
                var requestMethod = request.Headers.GetValues(MethodOverrideHeader).FirstOrDefault();

                if (AllowedMethods.Contains(requestMethod, StringComparer.InvariantCultureIgnoreCase))
                {
                    // Request Method를 override 처리
                    request.Method = new HttpMethod(requestMethod);
                }
            }
            else if(request.Method == HttpMethod.Put || request.Method == HttpMethod.Delete)
            {
                //throw new CustomBizException(ErrorCode.MethodNowAllowed);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}