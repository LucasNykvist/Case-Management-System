using CMS.DBModels;
using Microsoft.EntityFrameworkCore;

namespace CMS.Services
{
    internal class DisplayDataService
    {
        public void DisplayData(int CaseID)
        {
            using (var context = new CMSContext())
            {
                var caseToUpdate = context.Cases
                    .Include(c => c.Client)
                    .Include(c => c.Task)
                    .SingleOrDefault(c => c.CaseID == CaseID);

                var caseNotes = context.CaseNotes
                    .Where(n => n.CaseID == CaseID)
                    .ToList();

                if (caseToUpdate == null)
                {
                    Console.WriteLine($"No Data Was Found For Case with ID {CaseID}");
                    return;
                }

                Console.WriteLine($"\nCASE ID: {caseToUpdate.CaseID}");
                Console.WriteLine($"Client Name: {caseToUpdate.Client.FirstName} {caseToUpdate.Client.LastName}");
                Console.WriteLine($"Client Email: {caseToUpdate.Client.Email}");
                Console.WriteLine($"Client Phone Number: {caseToUpdate.Client.Phone}");
                Console.WriteLine($"Task Name: {caseToUpdate.Task.TaskName}");
                Console.WriteLine($"Task Description: {caseToUpdate.Task.TaskDescription}");
                Console.WriteLine($"Task Date Opened: {caseToUpdate.Task.DateOpened}");
                Console.WriteLine($"Task Status: {caseToUpdate.Task.Status}\n");

                Console.WriteLine($"Case Notes for Case with ID {CaseID}:");
                foreach (var note in caseNotes)
                {
                    Console.WriteLine($"{note.Note}");
                }

                if (caseNotes.Count == 0)
                {
                    Console.WriteLine($"No Case Notes Found for Case with ID {CaseID}");
                }

                Console.WriteLine("\nDo you want to update the status / add a note for this case? (Y/N): ");
                var response = Console.ReadLine();

                if (response.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Press 1 to change status");
                    Console.WriteLine("Press 2 to add a comment");

                    if (Int32.TryParse(Console.ReadLine(), out int statusOrComment))
                    {
                        switch (statusOrComment)
                        {
                            case 1:
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

                                caseToUpdate.Task.Status = newStatus;
                                context.SaveChanges();

                                Console.WriteLine($"Case with ID {CaseID} has been updated with new status {newStatus}\n");
                                Console.WriteLine("Press any key to continue...");
                                break;

                            case 2:
                                Console.Write("Add Note: ");
                                var newNote = Console.ReadLine();

                                var caseNote = new CaseNote { CaseID = CaseID, Note = newNote };
                                context.CaseNotes.Add(caseNote);
                                context.SaveChanges();

                                Console.WriteLine($"\nA new note has been added to Case with ID {CaseID}\n");
                                Console.WriteLine("Press any key to continue...");
                                break;

                        }
                    }




                }
                else if (response.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Status or Note of case with ID {CaseID} was not updated.\n");
                    Console.WriteLine("Press any key to continue...");
                }
            }
        }
    }
}
