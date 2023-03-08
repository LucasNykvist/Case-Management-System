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
                break;


            case 2:

                break;


            case 3:
                caseService.SearchCase();
                break;


            case 4:
                Console.WriteLine("Closing Program...");
                System.Threading.Thread.Sleep(1000);
                isRunning = false;
                break;

            default:
                Console.WriteLine("-------------- Invalid Menu Choice --------------");
                break;
        }
    }
}