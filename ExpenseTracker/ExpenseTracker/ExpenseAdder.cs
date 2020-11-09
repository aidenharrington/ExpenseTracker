using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker
{
    class ExpenseAdder
    {
        public static void AddExpenseLoop()
        {
            bool isLoop = true;

            while (isLoop == true)
            {
                isLoop = AddExpense();
            }
        }

        public static bool AddExpense()
        {
            DatabaseConnect dbConnect = new DatabaseConnect();
            //read categories from db
            List<string> categories = dbConnect.GetCategories();

            //read last date submitted from db
            string lastModifiedDate = dbConnect.GetLastModifiedDate();

            Date expenseDate;
            string category;
            string amount;

            try
            {
                expenseDate = GetDate(lastModifiedDate);
                category = GetCategory(categories, dbConnect);
                amount = GetAmount(category);

                dbConnect.WriteExpenseToDb(expenseDate, category, amount);

                bool addAnotherExpense = GetNextAction();

                return addAnotherExpense;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
                return false;
            }
        }

        private static Date GetDate(string lastModifiedDate)
        {
            if (lastModifiedDate == null)
            {
                lastModifiedDate = "No expenses submitted";
            }
            try
            {
                Console.Clear();
                Console.WriteLine("Adding an expense...");
                Console.WriteLine("Your last submitted expense was: " + lastModifiedDate);
                Console.WriteLine("Enter date for the expense you wish to submit in the format mm/dd/yyyy");
                
                string fullDate =  Console.ReadLine();

                Date date = StringToDate(fullDate);

                if (!date.ValidDate())
                {
                    throw new Exception();
                }

                return date;
            }
            catch
            {
                Console.WriteLine("Invalid date - press enter to try again");
                Console.ReadLine();
                return GetDate(lastModifiedDate);
            }
        }

        private static string GetCategory(List<string> categories, Date expenseDate, DatabaseConnect dbConnect)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please choose the category of the expense");

                int index = 0;
                if (categories.Count > 0)
                {
                    foreach (string category in categories)
                    {
                        Console.WriteLine((index + 1) + ". " + categories[index]);
                        index++;
                    }
                }

                Console.WriteLine((index + 1) + ". Add a new category");

                int selectedCategoryNumber = Int32.Parse(Console.ReadLine());

                if (selectedCategoryNumber == (index + 1))
                {
                    Console.WriteLine("Please enter the name of the new category");
                    string category = Console.ReadLine();

                    dbConnect.AddNewCategory(expenseDate, category);

                    return category;
                }
                else
                {
                    return categories[selectedCategoryNumber - 1];
                }
            }
            catch
            {
                Console.WriteLine("Invalid category - press enter to try again");
                Console.ReadLine();
                return GetCategory(categories);
            }

        }

        private static string GetAmount(string category)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the amount you wish to add for expense: " + category);

                string amount = Console.ReadLine();

                int amountInt = Int32.Parse(amount);

                if (amountInt <= 0)
                {
                    throw new Exception();
                }

                return amount;
            }
            catch
            {
                Console.WriteLine("Invalid amount - press enter to try again");
                Console.ReadLine();
                return GetAmount(category);
            }
        }

        private static bool GetNextAction()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Expense has successfully been added to the database");
                Console.WriteLine("Please choose next action");
                Console.WriteLine("1. Add another expense");
                Console.WriteLine("2. Return to main menu");

                string response = Console.ReadLine();

                if (response == "1")
                {
                    return true;
                }
                else if (response == "2")
                {
                    return false;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Invalid option - press enter to try again");
                Console.ReadLine();
                return GetNextAction();
            }
        }

        private static Date StringToDate(string fullDate)
        {
            string month = fullDate.Substring(0, 2);
            string day = fullDate.Substring(3, 2);
            string year = fullDate.Substring(6);

            Date date = new Date();
            date.month = Int32.Parse(month);
            date.day = Int32.Parse(day);
            date.year = Int32.Parse(year);

            return date;
        }

        
    }
}
