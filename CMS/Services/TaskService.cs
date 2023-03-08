using System.Numerics;
using CMS.Models;
using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class TaskService
    {

        static SqlConnection GetSqlConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lukep\Documents\Case Database.mdf"";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public int AddTask(int ClientID)
        {



            Console.WriteLine("\nEnter Task Information: ");

            Console.WriteLine("Task Type - Choose between 1-3 ");
            Console.WriteLine("1 - Software Issues");
            Console.WriteLine("2 - Hardware Issues");
            Console.WriteLine("3 - Other");
            string TaskName = "";

            if (Int32.TryParse(Console.ReadLine(), out int menuChoice))
            {
                switch (menuChoice)
                {
                    case 1:
                        TaskName = "Software Issues";
                        break;

                    case 2:
                        TaskName = "Hardware Issues";
                        break;

                    case 3:
                        TaskName = "Other";
                        break;

                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }

            Console.WriteLine($"Task Type Is: {TaskName}");

            Console.Write("Task Description: ");
            string TaskDescription = Console.ReadLine();

            DateTime DateOpened = DateTime.Now;
            string Status = "Pending";

            int TaskID = 0;

            using (SqlConnection connection = GetSqlConnection())
            {
                connection.Open();
                string Query = "INSERT INTO Tasks (ClientID, TaskName, TaskDescription, DateOpened, Status) VALUES (@ClientID, @TaskName, @TaskDescription, @DateOpened, @Status) SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", ClientID);
                    command.Parameters.AddWithValue("@TaskName", TaskName);
                    command.Parameters.AddWithValue("@TaskDescription", TaskDescription);
                    command.Parameters.AddWithValue("@DateOpened", DateOpened);
                    command.Parameters.AddWithValue("@Status", Status);
                    TaskID = Convert.ToInt32(command.ExecuteScalar());
                }

                return TaskID;
            }
        }
    }
}
