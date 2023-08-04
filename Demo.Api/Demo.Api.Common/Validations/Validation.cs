using System;

namespace Demo.Api.Common.Validations
{
    public static class Validation
    {
        public const Int32 timeout = 30;
 
        public const Int32 maxRowCount = 20000;
        public const string PATTERN_DATE_FORMAT = @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])$";
        public const string PATTERN_MONTH_FORMAT = @"^(19|20)\d{2}(0[1-9]|1[012])$";
    }
}