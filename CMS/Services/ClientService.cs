using CMS.DBModels;
using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class ClientService
    {
        public int AddClient()
        {
            Console.WriteLine("Skriv Klient Information:");

            Console.Write("Förnamn: ");
            string FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            string LastName = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer (ex: 7025541151): ");
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

                Console.WriteLine("\n----Klient Tillagd----");

                return client.ClientID;
            }
        }
    }
}
