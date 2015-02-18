using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayInfo.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime Next(this DateTime date, DayOfWeek dayOfWeek)
        {
            return date.AddDays((dayOfWeek < date.DayOfWeek ? 7 : 0) + dayOfWeek - date.DayOfWeek);
        }

        public static DateTime Previous(this DateTime date, DayOfWeek dayOfWeek)
        {
            date = date.AddDays(-1); // skip if already that day
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(-1);
            }
            return date;
        }

        public static DateTime FirstOfYear(this DateTime date, DayOfWeek dayOfWeek)
        {
            DateTime year = new DateTime(date.Year, 1, 1);
            while (year.DayOfWeek != dayOfWeek)
            {
                year = year.AddDays(1);
            }
            return year;
        }

        public static DateTime LastOfYear(this DateTime date, DayOfWeek dayOfWeek)
        {
            DateTime year = new DateTime(date.Year, 12, 31);
            while (year.DayOfWeek != dayOfWeek)
            {
                year = year.AddDays(-1);
            }
            return year;
        }

        /// <summary>
        /// use with last or first
        /// </summary>
        /// <param name="date"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime FirstOfMonth(this DateTime date, DayOfWeek dayOfWeek, Months month)
        {
            int monthDiff = ((int)month) - date.Month;
            DateTime year = new DateTime(date.Year, (int)month, 1);
            while (year.DayOfWeek != dayOfWeek)
            {
                year = year.AddDays(1);
            }
            return year;
        }

        public static DateTime LastOfMonth(this DateTime date, DayOfWeek dayOfWeek, Months month)
        {
            int monthDiff = ((int)month) - date.Month;
            DateTime year = new DateTime(date.Year, (int)month, DateTime.DaysInMonth(date.Year, (int)month));
            while (year.DayOfWeek != dayOfWeek)
            {
                year = year.AddDays(-1);
            }
            return year;
        }

        /// <summary>
        /// Returns the first day of the week that the specified
        /// date is in using the current culture. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            //cultureInfo.DateTimeFormat.
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            return firstDayInWeek;
        }
    }
}
