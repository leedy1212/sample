using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Api.Common.Errors.Models
{
    public class ErrorsModel
    {
        public ErrorsModel(ErrorModel errors)
        {
            Errors = errors;
        }

        public ErrorModel Errors { get; set; }
    }
}