using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GarantiPrisCalculator
    {
        private int Weekdaypay(int price, int hours)
        {
            return price * hours * 5;
        }

        private int WeekendPay(int price, int hours)
        {
            return price * hours * 2;
        }

        

        //public int TotalWeekPay(int weekdayPrice, int weekdayHours)
        //{
        //    return Weekdaypay(weekdayPrice, weekdayHours);
        //}

        //public int TotalWeekPay(int weekdayPrice, int weekdayHours, int weekendPay, int weekendHours)
        //{
        //    int week = Weekdaypay(weekdayPrice, weekdayHours);
        //    int weekend = WeekendPay(weekendPay, weekendHours);
        //    return week + weekend;
        //}

        
    }
}
