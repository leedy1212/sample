using SampleRest.Framework.DataConvertService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Api.Data.Enumerations
{
    public enum CommonEnum
    {
        [DBCode("0")]
        [Description("Unknown")]
        Unknown = 0,

        [DBCode("1")]
        [Description("User")]
        User = 1,
    }

}