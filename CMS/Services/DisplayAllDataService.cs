using CMS.DBModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CMS.Services
{
    internal class DisplayAllDataService
    {
        public void ShowAllData()
        {
            using (var db = new CMSContext())
            {
                var cases = db.Cases
                    .Include(c => c.Client)
                    .Include(c => c.Task)
                    .ToList();

                foreach (var item in cases)
                {
                    Console.WriteLine($"ÄRENDE ID: {item.CaseID}");
                    Console.WriteLine($"KLIENT NAMN: {item.Client.FirstName} {item.Client.LastName}");
                    Console.WriteLine($"KLIENT EMAIL: {item.Client.Email}");
                    Console.WriteLine($"KLIENT TELEFONNUMMER: {item.Client.Phone}");
                    Console.WriteLine($"ÄRENDE NAMN: {item.Task.TaskName}");
                    Console.WriteLine($"ÄRENDE BESKRIVNING: {item.Task.TaskDescription}");
                    Console.WriteLine($"ÄRENDE ÖPPNADES: {item.Task.DateOpened}");
                    Console.WriteLine($"ÄRENDE STATUS: {item.Task.Status}");
                    Console.WriteLine("");

                    var notes = db.CaseNotes.Where(cn => cn.CaseID == item.CaseID).ToList();
                    Console.WriteLine("Kommentarer:");
                    foreach (var note in notes)
                    {
                        Console.WriteLine($"- {note.Note}");
                    }

                    Console.WriteLine("");
                }
            }
        }
    }
}
