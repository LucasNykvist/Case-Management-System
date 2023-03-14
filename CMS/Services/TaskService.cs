using CMS.DBModels;
using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class TaskService
    {
        public int AddTask(int clientID)
        {
            Console.WriteLine("\nAnge Ärende Information: ");

            Console.WriteLine("Ärende Typ - Välj 1-3 ");
            Console.WriteLine("1 - Mjukvaru Problem");
            Console.WriteLine("2 - Hårdvara Problem");
            Console.WriteLine("3 - Annat");
            string taskName = "";

            if (Int32.TryParse(Console.ReadLine(), out int menuChoice))
            {
                switch (menuChoice)
                {
                    case 1:
                        taskName = "Mjukvaru Problem";
                        break;

                    case 2:
                        taskName = "Hårdvara Problem";
                        break;

                    case 3:
                        taskName = "Annat";
                        break;

                    default:
                        Console.WriteLine("Error - Välj Mellan 1 Och 3");
                        break;
                }
            }

            Console.WriteLine($"Ärende Typ Är: {taskName}");

            Console.Write("Ärende Beskrivning: ");
            string taskDescription = Console.ReadLine();

            DateTime dateOpened = DateTime.Now;
            string status = "Ej Påbörjad";


            using (var context = new CMSContext())
            {
                var task = new DBModels.Task
                {
                    ClientID = clientID,
                    TaskName = taskName,
                    TaskDescription = taskDescription,
                    DateOpened = dateOpened,
                    Status = status
                };

                context.Tasks.Add(task);
                context.SaveChanges();

                Console.WriteLine("\n----Ärende Tillagt----");

                return task.TaskID;
            }
        }
    }
}
