using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Demo.Api.Common;
using System.Web.Http.ExceptionHandling;
using Demo.Api.Common.Attribute;
using Demo.Api.Common.Validations;
using Demo.Api.Common.Filters;

namespace Demo.Api
{
    public static class FilterConfig
    { 
        public static void Register(HttpConfiguration config)
        {
            // Web API 구성 및 서비스
            config.MessageHandlers.Add(new ExtendedHeaderHandler());
            config.MessageHandlers.Add(new ErrorHttpMethodHandler());

            config.Filters.Add(new BaseExceptionFilterAttribute());
            config.Filters.Add(new RequestHeaderValidationAttribute());
            config.Filters.Add(new RequestBodyValidationAttribute());

        }
    }
}
