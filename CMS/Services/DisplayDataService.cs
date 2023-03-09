using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DBModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CMS.Services
{
    internal class DisplayDataService
    {
        /*public void DisplayData(int caseId)
        {
            using (var context = new CMSContext())
            {
                var caseDetails = context.Cases
                    .Where(c => c.CaseID == caseId)
                    .Include(c => c.Client)
                    .Include(c => c.Task)
                    .FirstOrDefault();

                if (caseDetails != null)
                {
                    Console.WriteLine($"CASE ID: {caseDetails.CaseID}");
                    Console.WriteLine($"Client Name: {caseDetails.Client.FirstName} {caseDetails.Client.LastName}");
                    Console.WriteLine($"Client Email: {caseDetails.Client.Email}");
                    Console.WriteLine($"Client Phone Number: {caseDetails.Client.Phone}");
                    Console.WriteLine($"Task Name: {caseDetails.Task.TaskName}");
                    Console.WriteLine($"Task Description: {caseDetails.Task.TaskDescription}");
                    Console.WriteLine($"Task Date Opened: {caseDetails.Task.DateOpened}");
                    Console.WriteLine($"Task Status: {caseDetails.Task.Status}\n");

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

                            caseToUpdate.Task.Status = 

                            break;

                        case "N":

                            break;

                        default:
                            Console.WriteLine("Invalid Menu Choice. Enter Y Or N");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine($"No Data Was Found For Case with ID {caseId}");
                }
            }
        }
    }*/

        public void DisplayData(int CaseID)
        {
            using (var context = new CMSContext())
            {
                var caseToUpdate = context.Cases.Include(c => c.Client).Include(c => c.Task).SingleOrDefault(c => c.CaseID == CaseID);

                if (caseToUpdate == null)
                {
                    Console.WriteLine($"No Data Was Found For Case with ID {CaseID}");
                    return;
                }

                Console.WriteLine($"CASE ID: {caseToUpdate.CaseID}");
                Console.WriteLine($"Client Name: {caseToUpdate.Client.FirstName} {caseToUpdate.Client.LastName}");
                Console.WriteLine($"Client Email: {caseToUpdate.Client.Email}");
                Console.WriteLine($"Client Phone Number: {caseToUpdate.Client.Phone}");
                Console.WriteLine($"Task Name: {caseToUpdate.Task.TaskName}");
                Console.WriteLine($"Task Description: {caseToUpdate.Task.TaskDescription}");
                Console.WriteLine($"Task Date Opened: {caseToUpdate.Task.DateOpened}");
                Console.WriteLine($"Task Status: {caseToUpdate.Task.Status}\n");

                Console.Write("Do you want to update the status of this case? (Y/N): ");
                var response = Console.ReadLine();

                if (response.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
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
                }
            }
        }
    }
}
