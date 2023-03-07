using CMS.Interfaces;

namespace CMS.Services
{
    internal class CaseService : ICaseService
    {
        public void AddCase()
        {
            Console.WriteLine("--- Add Case ---");

            Console.WriteLine("Enter Client Information:");
            Console.Write("First Name: ");
            Console.ReadLine();
            Console.Write("Last Name: ");
            Console.ReadLine();
            Console.Write("Email: ");
            Console.ReadLine();
            Console.Write("Phone Number: ");
            Console.ReadLine();

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
