using CMS.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace CMS.Services
{
    internal class CaseService : ICaseService
    {

        public void AddCase()
        {
            Console.WriteLine("--- Add Case ---");

            ClientService clientService= new ClientService();
            clientService.AddClient();

            Console.WriteLine("\nEnter Task Information: ");
            Console.Write("Task Name: ");
            Console.ReadLine();
            Console.Write("Task Description: ");
            Console.ReadLine();

            Console.WriteLine("\nCASE ADDED!\n");
        }

        public void GetAllCases()
        {

        }

        public void SearchCase()
        {

        }
    }
}
