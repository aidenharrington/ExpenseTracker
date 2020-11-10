﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using MySql.Data.MySqlClient;

namespace ExpenseTracker
{
    class DatabaseConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DatabaseConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "expense_tracker";
            uid = "root";
            password = "Tr!pl3sequels";

            string sqlConnectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";";
            connection = new MySqlConnection(sqlConnectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<string> GetCategories()
        {
            string sqlQuery = "SELECT category FROM categories";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            List<string> categories = new List<string>();
            
            try
            {
                OpenConnection();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string category = reader["category"].ToString();
                    categories.Add(category);
                }
                reader.Close();
                return categories;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public string GetLastModifiedDate()
        {
            string sqlQuery = "SELECT MAX(date_added) FROM expenses";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            string mostRecentDate = "";

            try
            {
                OpenConnection();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string date = reader["date_added"].ToString();
                    mostRecentDate = date;
                }
                reader.Close();
                return mostRecentDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void WriteExpenseToDb(Date expenseDate, string category, string amount)
        {
            string sqlInsertStatement = @"INSERT INTO expenses (user_id, category, amount, date_added) VALUES (@userId, @category, @amount, @dateAdded)";

            int categoryKey = GetCategoryKeyByName(category);

            using(MySqlCommand command = new MySqlCommand(sqlInsertStatement, connection))
            {
                command.Parameters.AddWithValue("@userId", 1);
                command.Parameters.AddWithValue("@category", categoryKey);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@dateAdded", expenseDate);

                OpenConnection();

                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    Console.WriteLine("Error inserting expense in to database");
                }

                CloseConnection();
            }
        }

        private int GetCategoryKeyByName(string category)
        {
            //TODO
            return 0;
        }

        public void AddNewCategory(Date expenseDate, string category)
        {
            //TODO
        }
    }
}
