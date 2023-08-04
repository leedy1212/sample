using System;
using System.Runtime.CompilerServices;
using Sample.Resources;

namespace Demo.Api.BizDac.Common.Utils
{
    public class EasySqlResourceLoader
    {
        public static string GetResource(Type callerType, [CallerMemberName] string callerMemberName = "")
        {
            return ResourceLoader.GetString(new SqlResourceLookup(callerType, callerMemberName));
        }
    }
}