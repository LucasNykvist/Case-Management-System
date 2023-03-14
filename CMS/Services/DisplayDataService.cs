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
                    Console.WriteLine($"Ingen Data Hittades För Ärende Med ID: {CaseID}");
                    return;
                }

                Console.WriteLine($"\nÄRENDE ID: {caseToUpdate.CaseID}");
                Console.WriteLine($"KLIENT NAMN: {caseToUpdate.Client.FirstName} {caseToUpdate.Client.LastName}");
                Console.WriteLine($"KLIENT EMAIL: {caseToUpdate.Client.Email}");
                Console.WriteLine($"KLIENT TELEFONNUMMER: {caseToUpdate.Client.Phone}");
                Console.WriteLine($"ÄRENDE NAMN: {caseToUpdate.Task.TaskName}");
                Console.WriteLine($"ÄRENDE BESKRIVNING: {caseToUpdate.Task.TaskDescription}");
                Console.WriteLine($"ÄRENDE ÖPPNADES: {caseToUpdate.Task.DateOpened}");
                Console.WriteLine($"ÄRENDE STATUS: {caseToUpdate.Task.Status}\n");

                Console.WriteLine($"KOMMENTARER FÖR ÄRENDE MED ID: {CaseID}:");
                foreach (var note in caseNotes)
                {
                    Console.WriteLine($"{note.Note}");
                }

                if (caseNotes.Count == 0)
                {
                    Console.WriteLine($"Inga Kommentarer Hittades För Ärende Med ID {CaseID}");
                }

                Console.WriteLine("\nVill Du Uppdatera Status / Lägga Till Kommentar För Detta Ärende? (Y/N): ");
                var response = Console.ReadLine();

                if (response.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Ange 1 För Att Ändra Status");
                    Console.WriteLine("Ange 2 För Att Lägga Till Kommentar");

                    if (Int32.TryParse(Console.ReadLine(), out int statusOrComment))
                    {
                        switch (statusOrComment)
                        {
                            case 1:
                                Console.WriteLine("Välj Ny Status");
                                Console.WriteLine("1: Ej Påbörjat");
                                Console.WriteLine("2: Pågående");
                                Console.WriteLine("3: Avslutad");
                                var newStatus = "";

                                if (Int32.TryParse(Console.ReadLine(), out int choice))
                                {
                                    switch (choice)
                                    {
                                        case 1:
                                            newStatus = "Ej Påbörjat";
                                            break;

                                        case 2:
                                            newStatus = "Pågående";
                                            break;

                                        case 3:
                                            newStatus = "Avslutad";
                                            break;

                                        default:
                                            Console.WriteLine("Error - Välj 1,2 Eller 3");
                                            break;
                                    }
                                }

                                caseToUpdate.Task.Status = newStatus;
                                context.SaveChanges();

                                Console.WriteLine($"Ärende Med ID {CaseID} Har Uppdaterats Med Ny Status: {newStatus}\n");
                                Console.WriteLine("Tryck På Valfri Tangent För Att Fortsätta...");
                                break;

                            case 2:
                                Console.Write("Ange Kommentar: ");
                                var newNote = Console.ReadLine();

                                var caseNote = new CaseNote { CaseID = CaseID, Note = newNote };
                                context.CaseNotes.Add(caseNote);
                                context.SaveChanges();

                                Console.WriteLine($"\nEn Ny Kommentar Har Lagts Till På Ärende Med ID: {CaseID}\n");
                                Console.WriteLine("Tryck På Valfri Tangent För Att Fortsätta...");
                                break;

                        }
                    }




                }
                else if (response.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Status Eller Kommentar På Ärende Med ID: {CaseID} Ändrades Inte...\n");
                    Console.WriteLine("Tryck På Valfri Tangent För Att Fortsätta...");
                }
            }
        }
    }
}
