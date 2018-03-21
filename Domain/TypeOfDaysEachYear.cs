using System;

namespace Domain
{
    public class TypeOfDaysEachYear
    {
        DateTime first;
        DateTime last;
        int year;

        // index 0 => weekdays | index 1 => weekenddays
        public int[] GetNumberOfDays()
        {
            year = new DateTime().Year;
            first = new DateTime(year, 1, 1);
            last = new DateTime(year, 12, 31);
            int weekdays = 0;
            int weekenddays = 0;
            while (first <= last)
            {
                if (first.DayOfWeek != DayOfWeek.Saturday && first.DayOfWeek != DayOfWeek.Sunday)
                {
                    weekdays++;
                }
                else
                {
                    weekenddays++;
                }
                first = first.AddDays(1);
            }
            int[] DaysInYear = { weekdays, weekenddays };
            return DaysInYear;
        }
    }
}
