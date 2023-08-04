using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Linq;
using Demo.Api.Common.Attribute;

namespace Demo.Api.Common.Filters
{
    public class SwaggerDefaultValueAttributeFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var actionParams = apiDescription.ActionDescriptor.GetParameters();
            var defaultValueAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerDefaultValueAttribute>();
            if (operation.parameters != null)
            {
                foreach (var param in operation.parameters)
                {
                    var defaultAttributes = defaultValueAttributes.FirstOrDefault(p => p.ParameterName == param.name);
                    if (defaultAttributes != null)
                    {
                        param.@default = defaultAttributes.Value;
                    }
                }
            }
        }
    }
}