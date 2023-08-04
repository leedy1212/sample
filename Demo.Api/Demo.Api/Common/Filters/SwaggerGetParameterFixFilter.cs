using System;
using System.Linq;
using System.Net.Http;
using System.Collections;
using Swashbuckle.Swagger;
using System.Web.Http.Description;

namespace Demo.Api.Common.Filters
{
    public class SwaggerGetParameterFixFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.HttpMethod.Equals(HttpMethod.Get))
            {

                if (apiDescription.ParameterDescriptions.Count > 0)
                {
                    foreach (var httpParameterDescriptor in apiDescription.ActionDescriptor.GetParameters()
                                 .Where(e => !e.ParameterType.FullName.StartsWith("System")))
                    {
                        Parameter param;
                        String prefixName = httpParameterDescriptor.ParameterName + ".";

                        var parameters = operation.parameters;
                        IEnumerator paramsEnum = parameters.GetEnumerator();
                        while (paramsEnum.MoveNext())
                        {
                            param = (Parameter)paramsEnum.Current;
                            if (param.@in.Equals("query"))
                            {
                                param.@name = param.@name.Replace(prefixName, "");
                            }
                        }
                    }
                }
            }
        }
    }
}