using System;
using System.Globalization;

namespace WeekOfYear
{
    internal static class WeekHelper
    {
        public static int WeekOfYearIso8601(this DateTime date)
        {
            var day = (int) CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)),
                CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}