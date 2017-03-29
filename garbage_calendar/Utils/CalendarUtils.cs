using System;

namespace garbage_calendar.Utils
{
    public class CalendarUtils
    {
        public static int CalcRowSize(int year, int month)
        {
            var diff = CalcPrevMonthDays(year, month);
            var endOfDay = DateTime.DaysInMonth(year, month);
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
    }
}