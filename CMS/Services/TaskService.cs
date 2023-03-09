using CMS.DBModels;
using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class TaskService
    {
        public int AddTask(int clientID)
        {
            Console.WriteLine("\nEnter Task Information: ");

            Console.WriteLine("Task Type - Choose between 1-3 ");
            Console.WriteLine("1 - Software Issues");
            Console.WriteLine("2 - Hardware Issues");
            Console.WriteLine("3 - Other");
            string taskName = "";

            if (Int32.TryParse(Console.ReadLine(), out int menuChoice))
            {
                switch (menuChoice)
                {
                    case 1:
                        taskName = "Software Issues";
                        break;

                    case 2:
                        taskName = "Hardware Issues";
                        break;

                    case 3:
                        taskName = "Other";
                        break;

                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }

            Console.WriteLine($"Task Type Is: {taskName}");

            Console.Write("Task Description: ");
            string taskDescription = Console.ReadLine();

            DateTime dateOpened = DateTime.Now;
            string status = "Pending";


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

                Console.WriteLine("\n----Task Added----");

                return task.TaskID;
            }
        }
    }
}
