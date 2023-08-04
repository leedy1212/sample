using System;
using System.Globalization;

namespace Demo.Api.Common.Utils
{
    /// <summary>
    /// This file is a helper class for internal usage only.
    /// Be aware that its API and functionality may be changed in future.
    /// </summary>
    public static class DateTimeUtil 
    {
        private static readonly String DEFAULT_PATTERN = "yyyy-MM-dd";
        
        public static int ConvertTimeStamp(DateTime time)
        {
            DateTime d1; 
            DateTime d2;
            TimeSpan d3;
            int timeStamp = 0;

            d1 = DateTime.Parse("1960-01-01 09:00:00"); //기준시간
            d2 = time; //현재 시간
            d3 = d2 - d1; //현재시간 - 기준시간
            timeStamp = Convert.ToInt32(d3.TotalSeconds); //타임스탬프

            return timeStamp;
        }

        /// <summary>
        /// Gets the date time as UTC milliseconds from the epoch.
        /// </summary>
        /// <param name="dateTime">date to be converted to millis</param>
        /// <returns>the date as UTC milliseconds from the epoch</returns>
        public static double GetUtcMillisFromEpoch(DateTime? dateTime) {
            if (dateTime == null) {
                dateTime = GetCurrentUtcTime();
            }
            return (dateTime.Value.ToUniversalTime() - GetInitial()).TotalMilliseconds;
        }

        /// <summary>
        /// Gets the calendar date and time of a day.
        /// </summary>
        /// <param name="dateTime">the date to be returned as calendar</param>
        /// <returns>the calendar date and time of a day</returns>
        public static DateTime GetCalendar(DateTime dateTime) { 
            return dateTime;
        }

        /// <summary>
        /// Gets the current time in the default time zone with the default locale.
        /// </summary>
        /// <returns>the current time in the default time zone with the default locale</returns>
        public static DateTime GetCurrentTime() {
            return DateTime.Now;
        }

        /// <summary>
        /// Gets the current time consistently.
        /// </summary>
        /// <returns>the time at which it was allocated, measured to the nearest millisecond</returns>
        public static DateTime GetCurrentUtcTime() {
            return DateTime.UtcNow;
        }
        
        /// <summary>
        /// Defines if date is in past.
        /// </summary>
        /// <returns>true if given date is in past, false instead</returns>
        public static bool IsInPast(DateTime date) {
            return date.CompareTo(GetCurrentTime()) < 0;
        }

        /// <summary>
        /// Gets the number of milliseconds since January 1, 1970, 00:00:00 GMT represented by specified date.
        /// </summary>
        /// <param name="date">the specified date to get time</param>
        /// <returns>the number of milliseconds since January 1, 1970, 00:00:00 GMT represented by the specified date</returns>
        public static long GetRelativeTime(DateTime date) {
            return (long) (date.ToUniversalTime() - GetInitial()).TotalMilliseconds;
        }

        /// <summary>
        /// Parses passing date with default {@code yyyy-MM-dd} pattern.
        /// </summary>
        /// <param name="date">date is date to be parse</param>
        /// <returns>parse date</returns>
        public static DateTime ParseWithDefaultPattern(String date) {
            return Parse(date, DEFAULT_PATTERN);
        }
        
        /// <summary>
        /// Parses passing date with specified format.
        /// </summary>
        /// <param name="date">the date to be parsed</param>
        /// <param name="format">the format of parsing the date</param>
        /// <returns>parsed date</returns>
        public static DateTime Parse(String date, String format) {
            // The method is rarely called, so every time we create a new DateTimeFormatInfo (necessary for automatic testing)
            DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
            dateTimeFormatInfo.Calendar = new GregorianCalendar();
            return DateTime.ParseExact(date, format, dateTimeFormatInfo);
        }

        /// <summary>
        /// Format passing date with default yyyy-MM-dd pattern.
        /// </summary>
        /// <param name="date">the date to be formatted</param>
        /// <returns>formatted date</returns>
        public static String FormatWithDefaultPattern(DateTime date) {
            return Format(date, DEFAULT_PATTERN);
        }
        
        /// <summary>
        /// Format passing date with specified pattern.
        /// </summary>
        /// <param name="date">the date to be formatted</param>
        /// <param name="pattern">pattern for format</param>
        /// <returns>formatted date</returns>
        public static String Format(DateTime date, String pattern)
        {
            return date.ToString(pattern, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the offset of time zone from UTC at the specified date.
        /// </summary>
        /// <param name="date">the date represented in milliseconds since January 1, 1970 00:00:00 GMT</param>
        /// <returns>the offset of time zone from UTC at the specified date adjusted with the amount of daylight saving.</returns>
        public static long GetCurrentTimeZoneOffset(DateTime date) {
            TimeZone tz = TimeZone.CurrentTimeZone;
            return (long) tz.GetUtcOffset(date).TotalMilliseconds;
        }

        private static DateTime GetInitial() {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }
    }
}