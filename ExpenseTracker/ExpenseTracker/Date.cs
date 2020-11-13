using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExpenseTracker
{
    public class Date
    {
        public int month;
        public int day;
        public int year;

        private static List<int> longMonths = new List<int>() { 1, 3, 5, 7, 8, 10, 12 };

        public bool ValidDate()
        {
            return CheckMonth() && CheckDate() && CheckYear();
        }

        public bool CheckMonth()
        {
            return month >= 1 && month <= 12;
        }

        public bool CheckDate()
        {
            if (month == 2)
            {
                return day >= 1 && day <= 29;
            }
            else if (longMonths.Contains(month))
            {
                return day >= 1 && day <= 31;
            }
            else
            {
                return day >= 1 && day <= 30;
            }
        }
        public bool CheckYear()
        {
            return year >= 1900 && year <= 2100;
        }

        public DateTime GetDateTime()
        {
            DateTime dateTime = new DateTime(year, month, day);
            return dateTime;
        }
    }
}
