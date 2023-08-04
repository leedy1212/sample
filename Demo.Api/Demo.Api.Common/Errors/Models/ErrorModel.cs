using System;

namespace Demo.Api.Common.Errors.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            Code = 0;
            Name = String.Empty;
            Message = String.Empty;
        }
        public ErrorModel(int code, string name, string message)
        {
            Code = code;
            Name = name;
            Message = message;
        }

        public int Code { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public object Details { get; set; }
    }
}