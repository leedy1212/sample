using System;
using System.Linq;
using System.Net.Http;
using System.Collections;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using Demo.Api.Common.Attribute;

namespace Demo.Api.Common.Filters
{
    public class SwaggerCustomOperationFilter : IOperationFilter
    {
        // public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        // {
        //     operation.consumes.Clear(); // 기존  Request content type 제거
        //     operation.consumes.Add("application/json; charset=UTF-8"); // 신규 Request content type 추가
        //     operation.produces.Clear(); // 기존  Response content type 제거
        //     operation.produces.Add("application/json+sample"); // 신규  Response content type 추가
        // }

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.consumes.Clear(); // 전체 Request content type 제거
            operation.consumes.Add("application/json; charset=UTF-8"); // 신규 Request content type 추가
            var requestAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerRequestContentTypeAttribute>();
            foreach (var requestAttribute in requestAttributes)
            {
                if (requestAttribute.Exclusive)
                {
                    operation.consumes.Clear();
                }
                operation.consumes.Insert(0, requestAttribute.RequestType);
                 
            }
             
            var responseAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerResponseContentTypeAttribute>();
            foreach (var responseAttribute in responseAttributes)
            {
                if (responseAttribute.Exclusive)
                {
                    operation.produces.Clear();
                }
                operation.produces.Insert(0, responseAttribute.ResponseType);
            }
        }
        
    }
    
}