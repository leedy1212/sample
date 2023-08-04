using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Demo.Api.Common.Errors.Attributes
{
    public class HttpStatusCodeAttribute : Attribute
    {
        public HttpStatusCodeAttribute(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }

        public HttpStatusCode HttpStatusCode { get; private set; }
    }
}