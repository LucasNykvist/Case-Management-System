using CMS.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Identity.Client;

namespace CMS.Services
{
    internal class CaseService : ICaseService
    {
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

        public void SearchCase()
        {
            Console.WriteLine("Enter Case ID");
            Int32.TryParse(Console.ReadLine(), out int CaseID);

            DisplayDataService displayDataService = new DisplayDataService();
            displayDataService.DisplayData(CaseID);
        }

        public void GetAllCases()
        {

        }
    }
}
