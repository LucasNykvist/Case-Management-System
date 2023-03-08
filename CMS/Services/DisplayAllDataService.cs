using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class DisplayAllDataService
    {

        static SqlConnection GetSqlConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lukep\Documents\Case Database.mdf"";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public void ShowAllData()
        {

            using (SqlConnection connection = GetSqlConnection())
            {
                string query = "SELECT * FROM Cases " +
                               "INNER JOIN Clients ON Cases.ClientID = Clients.ClientID " +
                               "INNER JOIN Tasks ON Cases.TaskID = Tasks.TaskID";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"CASE ID: {reader["CaseID"]}");
                        Console.WriteLine($"Client Name: {reader["FirstName"]} {reader["LastName"]}");
                        Console.WriteLine($"Client Email: {reader["Email"]}");
                        Console.WriteLine($"Client Phone Number: {reader["Phone"]}");
                        Console.WriteLine($"Task Name: {reader["TaskName"]}");
                        Console.WriteLine($"Task Description: {reader["TaskDescription"]}");
                        Console.WriteLine($"Task Date Opened: {reader["DateOpened"]}");
                        Console.WriteLine($"Task Status: {reader["Status"]}");
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
}
