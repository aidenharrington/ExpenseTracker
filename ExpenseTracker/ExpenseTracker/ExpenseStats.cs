using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker
{
    class ExpenseStats
    {
        public static void GetStatsLoop()
        {
            bool isLoop = true;

            while (isLoop)
            {
                isLoop = GetStats();
            }
        }
        public static bool GetStats()
        {
            Date date = GetDateForStats();
            PrintStats(date);

            bool getMoreStats = GetNextAction();

            return getMoreStats;
        }

        private static Date GetDateForStats()
        {
            //TODO 
            //run console loop to get input date
            //use * as wild card
            try
            {
                Console.Clear();
                Console.WriteLine("Please enter the date corresponding to the expense stats you wish to see using ** as wildcard");
                Console.WriteLine("Example: to get all expenses for February 2020, enter: 02/**/2020");
            }
            catch (Exception ex)
            {

            }


            throw new NotImplementedException();
        }

        private static void PrintStats(Date date)
        {
            //TODO
            //write to console all stats for specified date
            //format of date at top then amount beside each category
        }

        private static bool GetNextAction()
        {
            //TODO
            return false;
        }
    }
}
