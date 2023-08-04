using System;

namespace Demo.Api.Common.Attribute
{
    // <summary>
    // SwaggerResponseContentTypeAttribute
    // </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SwaggerDefaultValueAttribute : System.Attribute
    {
        /// <summary>
        /// SwaggerDefaultValueAttribute
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        public SwaggerDefaultValueAttribute(string parameterName, object value)
        {
            this.ParameterName = parameterName;
            this.Value = value;
        }
    
        /// <summary>
        /// DefaultValue parameter Name
        /// </summary>
        public string ParameterName { get; private set; }
    
        /// <summary>
        /// DefaultValue parameter value
        /// </summary>
        public object Value { get; set; }
    }
}