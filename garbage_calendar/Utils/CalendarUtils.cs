using System;

namespace garbage_calendar.Utils
{
    public class CalendarUtils
    {
        public static int CalcRowSize(int year, int month)
        {
            var date = new DateTime(year, month, 1);
            var startWeek = date.DayOfWeek;
            var diff = startWeek - DayOfWeek.Sunday;
            var endOfDay = DateTime.DaysInMonth(year, month);
            var cellCountWithPrefix = diff + endOfDay;
            if (cellCountWithPrefix % 7 == 0)
            {
                return cellCountWithPrefix / 7;
            }

            return cellCountWithPrefix / 7 + 1;
        }
    }
}