using System;

namespace garbage_calendar.Repository
{
    public class GarbageDay
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}