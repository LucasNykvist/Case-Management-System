using CMS.Interfaces;

namespace CMS.Services
{
    internal class Menu : IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("---Ärendehanteringssystem---");

            Console.WriteLine("MENY 1: Skapa Ärende");

            Console.WriteLine("MENY 2: Visa alla ärenden");

            Console.WriteLine("MENY 3: Specifikt Ärende / Status / Kommentarer");

            Console.WriteLine("MENY 4: Avsluta Program");
        }
    }
}
