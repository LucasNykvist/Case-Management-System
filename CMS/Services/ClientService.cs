﻿using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class ClientService
    {

        static SqlConnection GetSqlConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lukep\Documents\Case Database.mdf"";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public int AddClient()
        {
            Console.WriteLine("Enter Client Information:");

            Console.Write("First Name: ");
            string FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();

            Console.Write("Email: ");
            string Email = Console.ReadLine();

            Console.Write("Phone Number (eg: 7025541151): ");
            string Phone = Console.ReadLine();

            int ClientID = 0;

            using (SqlConnection connection = GetSqlConnection())
            {
                connection.Open();
                string query = "INSERT INTO Clients (FirstName, LastName, Email, Phone) VALUES (@FirstName, @LastName, @Email, @Phone) SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    ClientID = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("\n----Client Added----");
                }
            }

            return ClientID;
        }
    }
}
