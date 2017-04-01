using System;
using System.Diagnostics;

namespace garbage_calendar.Utils
{
    public class CalendarUtils
    {
        public static int CalcRowSize(int year, int month)
        {
            var diff = CalcPrevMonthDays(year, month);
            var endOfDay = GetCountOfDays(year, month);
            var cellCountWithPrefix = diff + endOfDay;
            if (cellCountWithPrefix % 7 == 0)
            {
                return cellCountWithPrefix / 7;
            }

            return cellCountWithPrefix / 7 + 1;
        }

        public static int CalcPrevMonthDays(int year, int month)
        {
            var date = new DateTime(year, month, 1);
            var startWeek = date.DayOfWeek;
            return startWeek - DayOfWeek.Sunday;
        }

        public static int CalcNextMonthDays(int year, int month)
        {
            var date = new DateTime(year, month, 1);
            var endOfDay = DateTime.DaysInMonth(year, month);
            date = new DateTime(year, month, endOfDay);

            var startWeek = date.DayOfWeek;

            return DayOfWeek.Saturday - startWeek;
        }

        public static int GetCountOfDays(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static DateTime CalcDate(int year, int month, int prevMonthDays, int idx)
        {
            // 前の月
            if (prevMonthDays >= idx)
            {
                var dateTime = new DateTime(year, month, 1);
                dateTime = dateTime.AddMonths(-1);
                var lastDay = GetCountOfDays(dateTime.Year, dateTime.Month);

                Debug.WriteLine("{0}/{1}/{2}", dateTime.Year, dateTime.Month, lastDay - prevMonthDays + idx);

                return new DateTime(dateTime.Year, dateTime.Month, lastDay - prevMonthDays + idx);
            }
            else
            {
                var lastDay = GetCountOfDays(year, month);
                // 当月
                if (lastDay + prevMonthDays >= idx)
                {
                    return new DateTime(year, month, idx - prevMonthDays);
                }
                // 次の月
                var dateTime = new DateTime(year, month, 1);
                dateTime = dateTime.AddMonths(1);

                Debug.WriteLine("{0}/{1}/{2}", dateTime.Year, dateTime.Month, idx - lastDay - prevMonthDays);

                return new DateTime(dateTime.Year, dateTime.Month, idx - lastDay - prevMonthDays);
            }
        }
    }
}