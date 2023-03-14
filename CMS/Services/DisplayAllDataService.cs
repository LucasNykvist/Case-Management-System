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
                    Console.WriteLine($"CASE ID: {item.CaseID}");
                    Console.WriteLine($"Client Name: {item.Client.FirstName} {item.Client.LastName}");
                    Console.WriteLine($"Client Email: {item.Client.Email}");
                    Console.WriteLine($"Client Phone Number: {item.Client.Phone}");
                    Console.WriteLine($"Task Name: {item.Task.TaskName}");
                    Console.WriteLine($"Task Description: {item.Task.TaskDescription}");
                    Console.WriteLine($"Task Date Opened: {item.Task.DateOpened}");
                    Console.WriteLine($"Task Status: {item.Task.Status}");
                    Console.WriteLine("");

                    var notes = db.CaseNotes.Where(cn => cn.CaseID == item.CaseID).ToList();
                    Console.WriteLine("Notes:");
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
