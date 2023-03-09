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

            Console.WriteLine("Change Status Of This Case? Y/N");

            string menuChoice = Console.ReadLine().ToUpper();
            switch (menuChoice)
            {
                case "Y":
                    Console.WriteLine("Choose New Status");
                    Console.WriteLine("1: Pending");
                    Console.WriteLine("2: Ongoing");
                    Console.WriteLine("3: Closed");
                    var newStatus = "";

                    if (Int32.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                newStatus = "Pending";
                                break;

                            case 2:
                                newStatus = "Ongoing";
                                break;

                            case 3:
                                newStatus = "Closed";
                                break;

                            default:
                                Console.WriteLine("Error - Choose between 1,2 or 3");
                                break;
                        }
                    }

                    break;

                case "N":

                    break;

                default: 
                    Console.WriteLine("Invalid Menu Choice. Enter Y Or N");
                    break;
            }
        }

        public void GetAllCases()
        {
            DisplayAllDataService displayAllData = new DisplayAllDataService();
            displayAllData.ShowAllData();
        }
    }
}
