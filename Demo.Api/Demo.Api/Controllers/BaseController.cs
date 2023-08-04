using SampleFx.Diagnostics;
using SampleRest.Api.Response;
using SampleRest.Api.Server.Filter;
using SampleRest.Api.Server.SOA;
using SampleRest.Framework.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Demo.Api.Controllers
{
    [RoutePrefix("api/base")]
    [ApiTracingFilter(EnumServiceType.Test1)]
    [ApiExceptionFilter]
    public class BaseController : ApiControllerBase
    {
        [HttpPost]
        [Route("trace")]
        public ApiResponse<string> BaseTest(RequestT request)
        {
            TraceContext traceContext = TraceContext.Current;
            TraceEntry entry = null;

            foreach (TraceEntry traceEntry in traceContext.TraceEntryList)
            {
                if(
                    traceEntry.Category.Name == TraceCategory.NAME_ENTERPRISESERVICES &&
                    !string.IsNullOrEmpty(traceEntry.Message) &&
                    traceEntry.Message.StartsWith("{") &&
                    traceEntry.Message.EndsWith("}\r\n")
                )
                { 
                    entry = traceEntry;
                }
            }

            return new ApiResponse<string>
            {
                ResultCode = 1,
                Data = entry.Message,
                Message = "success"
            };
        }   
    }

    public class RequestT
    {
        public string RequestMessage {get; set;}
        public int Age { get; set; }
    }
}
