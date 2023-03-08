using CMS.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CMS.Services
{
    internal class CaseService : ICaseService
    {

        static SqlConnection GetSqlConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lukep\Documents\Case Database.mdf"";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public void AddCase()
        {
            Console.WriteLine("--- Add Case ---");

            ClientService clientService = new ClientService();
            int ClientID = clientService.AddClient();

            TaskService taskService = new TaskService(); 
            int TaskID = taskService.AddTask(ClientID);

            CombinerService combinerService= new CombinerService();
            combinerService.CombineClientTask(ClientID, TaskID);
        }

        public void GetAllCases()
        {

        }

        public void SearchCase()
        {

        }
    }
}
