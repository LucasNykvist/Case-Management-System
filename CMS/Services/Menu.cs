using CMS.Interfaces;

namespace CMS.Services
{
    internal class Menu : IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("---CASE MANAGEMENT SYSTEM---");

            Console.WriteLine("MENU 1: Create Case");

            Console.WriteLine("MENU 2: Show All Cases");

            Console.WriteLine("MENU 3: Specific Case / Status / Notes");

            Console.WriteLine("MENU 4: CLOSE CASE MANAGEMENT SYSTEM");
        }
    }
}
