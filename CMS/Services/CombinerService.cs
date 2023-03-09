using CMS.DBModels;
using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class CombinerService
    {
        public void CombineClientTask(int ClientID, int TaskID)
        {
            using (var context = new CMSContext())
            {
                var newCase = new Case
                {
                    ClientID = ClientID,
                    TaskID = TaskID
                };

                context.Cases.Add(newCase);
                context.SaveChanges();

                Console.WriteLine("Case Has Been Added...");
            }
        }
    }
}
