using CMS.Services;

CaseService caseService= new CaseService();

bool isRunning = true;

while (isRunning)
{
    Menu menu = new Menu();

    menu.ShowMenu();

    if (Int32.TryParse(Console.ReadLine(), out int menuChoice))
    {
        switch (menuChoice)
        {

            case 1:
                caseService.AddCase();
                Console.ReadKey();
                Console.Clear();
                break;


            case 2:
                caseService.GetAllCases();
                Console.ReadKey();
                Console.Clear();
                break;


            case 3:
                caseService.SearchCase();
                Console.ReadKey();
                Console.Clear();
                break;

            case 4:
                Console.WriteLine("Stänger Program...");

                //Enbart lagt till detta för att det ska "kännas" lite (=
                System.Threading.Thread.Sleep(1000);
                isRunning = false;
                break;

            default:
                Console.WriteLine("-------------- Ogiltigt Menyval --------------");
                break;
        }
    }
}