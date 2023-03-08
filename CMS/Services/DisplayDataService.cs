using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class DisplayDataService
    {
        static SqlConnection GetSqlConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lukep\Documents\Case Database.mdf"";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public void DisplayData(int CaseID)
        {
            using (SqlConnection connection = GetSqlConnection())
            {
                connection.Open();

                var query = "SELECT " +
                        "c.CaseID, " +
                        "cl.FirstName, " +
                        "cl.LastName, " +
                        "cl.Email, " +
                        "cl.Phone, " +
                        "t.TaskName, " +
                        "t.TaskDescription, " +
                        "t.DateOpened, " +
                        "t.Status " +
                    "FROM Cases c " +
                        "JOIN Clients cl ON c.ClientID = cl.ClientID " +
                        "JOIN Tasks t ON c.TaskID = t.TaskID " +
                    "WHERE c.CaseID = @caseId";

                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@CaseID", CaseID);

                    using (var reader = command.ExecuteReader()) 
                    {
                        if(reader.Read()) 
                        {
                            Console.WriteLine($"CASE ID: {reader["CaseID"]}");
                            Console.WriteLine($"Client Name: {reader["FirstName"]} {reader["LastName"]}");
                            Console.WriteLine($"Client Email: {reader["Email"]}");
                            Console.WriteLine($"Client Phone Number: {reader["Phone"]}");
                            Console.WriteLine($"Task Name: {reader["TaskName"]}");
                            Console.WriteLine($"Task Description: {reader["TaskDescription"]}");
                            Console.WriteLine($"Task Date Opened: {reader["DateOpened"]}");
                            Console.WriteLine($"Task Status: {reader["Status"]}\n");
                        }
                        else
                        {
                            Console.WriteLine($"No Data Was Found For Case with ID {CaseID}");
                        }
                    }

                }
            }
        }
    }
}
