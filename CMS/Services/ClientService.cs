using CMS.DBModels;
using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class ClientService
    {
        public int AddClient()
        {
            Console.WriteLine("Enter Client Information:");

            Console.Write("First Name: ");
            string FirstName = Console.ReadLine() ?? "";

            Console.Write("Last Name: ");
            string LastName = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string Email = Console.ReadLine() ?? "";

            Console.Write("Phone Number (eg: 7025541151): ");
            string Phone = Console.ReadLine() ?? "";

            using (var context = new CMSContext())
            {
                var client = new Client
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Phone = Phone
                };

                context.Clients.Add(client);
                context.SaveChanges();

                Console.WriteLine("\n----Client Added----");

                return client.ClientID;
            }
        }
    }
}
