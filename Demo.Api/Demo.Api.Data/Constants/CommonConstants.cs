using System;

namespace Demo.Api.Data.Constants
{
    public static class Constants
    {
        public const Int32 Timeout = 50000;
        public const Int32 LongTimeout = 100000;
    }

    public static class ConstError
    {
        public const Int32 OK = 0;
        public const Int32 Unknown = 999;
    }

    public static class ConstCommon
    {
        public const String StringYes = "Y";
        public const String StringNo = "N";

        public const String StringDev = "DEV";
    }
}