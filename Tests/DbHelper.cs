using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Tests.Models;

namespace Tests
{
    public class DbHelper
    {
        //const string ConnectionString = @"Server=KBP1-LHP-A05687\SQLEXPRESS;Database=Employees;Integrated Security=True"; 
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public static void GetAll()
        {
            var employees = new List<Employee>();

            // Establish the connection
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Example query
                    const string query = "SELECT * FROM EmployeeInfo";

                    // Execute the query
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Execute the reader
                        using (var reader = command.ExecuteReader())
                        {
                            // Check if the reader has rows
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var employee = new Employee();
                                    employee.Name = reader["Name"].ToString();
                                    employee.Jobtitle = reader["JobTitle"].ToString();
                                    employee.Level = Convert.ToInt32(reader["Level"]);
                                    employees.Add(employee);

                                    // Access data using column names
                                    var name = reader["Name"].ToString();
                                    var jobTitle = reader["JobTitle"].ToString();
                                    var level = Convert.ToInt32(reader["Level"]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static void Insert(Employee employee)
        {
            // Establish the connection
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Example insert query
                     var insertQuery =
                        $"INSERT INTO EmployeeInfo (Name, JobTitle, Level) VALUES ('{employee.Name}', '{employee.Jobtitle}', {employee.Level})";

                    using (var insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        var rowsAffected = insertCommand.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {rowsAffected}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}