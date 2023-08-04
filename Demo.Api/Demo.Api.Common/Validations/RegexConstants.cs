namespace Demo.Api.Common.Validations
{
    public class RegexConstants
    {
        /*
        Regex regex = Regex(@"^[0-9a-zA-Z]{1,100}$");
        숫자,영어를 포함한 1~100사이의문자열
        $를 끝에 사용해서 숫자,영어로 끝나야만 한다.
        */
        public const string PATTERN_USER_ID = @"^[0-9a-zA-Z]{1,100}$";
        public const string PATTERN__REGEX_PUMA_CATEGORY = @"(warning) (SEC)[\d]+:";
        public const string PATTERN__REGEX_PUMA_ERROR_CODE = @"(SEC)[\d]+";
        public const string PATTERN__REGEX_RULE_SEVERITY = @"([^\s]+)";
        public const string PATTERN__REGEX_FULL_WIN_FILE_PATH = @"\b[A-Z]:\\(?:[^\\/:*?""<>|\x00-\x1F]+\\)*[^\\/:*?""<>|\x00-\x1F\]]*";
        public const string PATTERN__REGEX_WIN_DIRECTORY = @"([A-Z]:|\\\\[a-z0-9 %._-]+\\[a-z0-9 $%._-]+)?(\\?(?:[^\\/:*?""<>|\x00-\x1F]+\\)+)";
        public const string PATTERN__REGEX_VS_RELATIVE_PATH = @"([^\\/:*?""<>|\x00-\x1F]+\\)*[^\\/:*?""<>|\x00-\x1F]+\(\d+,\d+\)";
        public const string PATTERN__REGEX_WARNING_DELIMITER = @":\ \[?";
        public const char PATTERN__PATH_DELIMETER_OPEN = '(';
        public const char PATTERN__PATH_DELIMETER_CLOSE = ')';
        public const char PATTERN__LOCATION_DELIMETER = ',';
        public const char PATTERN__PROJECT_DELIMETER_OPEN = '[';
        public const char PATTERN__PROJECT_DELIMETER_CLOSE = ']';
        public const string PATTERN__MS_BUILD_WARNING_FORMAT = @"{0}({1},{2}): warning {3}: {4} [{5}]";
        public const string PATTERN__REGEX_ADDITIONAL_FILES_PATH = @" [A-Za-z]:\\[A-Za-z0-9 %\._-]+";
        public const string PATTERN__REGEX_ADDITIONAL_FILES_METADATA = @" \{0\}(\{1\}): \{2\}";
    }
}