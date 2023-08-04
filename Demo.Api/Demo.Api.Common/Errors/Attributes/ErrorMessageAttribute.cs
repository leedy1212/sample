using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Api.Common.Errors.Attributes
{
    public class ErrorMessageAttribute : Attribute
    {
        public ErrorMessageAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; private set; }
    }
}
