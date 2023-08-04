using SampleRest.Framework.DataConvertService;

namespace Demo.Api.Common.Enumerations
{
    public enum EnumDomain
    {
        [DBCode("0")]
        [Description("Unknown")]
        Unknown = 0,

        [DBCode("1")]
        [Description("User")]
        User = 1,
    }
}