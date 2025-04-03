namespace Flow_Control
{
    internal class Program
    {
        static void Main()
        {
            MenuChoice menuChoice = new();
            bool programIsRunning = true;
            int index = 0;

            Console.WriteLine
                ("Du har nu kommit fram till huvudmenyn\n\n" +
                "Använd piltangenterna för att navigera i menyn och ENTER för att välja ett val\n\n" +
                "Klicka på valfri tangent för att fortsätta till huvudmenyn...");

            Console.ReadLine();

            while (programIsRunning)
            {
                index = Menu.InitializeMenu
                (
                    [
                        "Menyval 1",
                        "Menyval 2",
                        "Menyval 3"
                    ], index
                );

                switch (index)
                {
                    case 0:
                        menuChoice.One();
                        break;

                    case 1:
                        menuChoice.Two();
                        break;

                    case 2:
                        menuChoice.Three();
                        break;

                    case 3:
                        programIsRunning = false;
                        break;
                };
                
            }



            Environment.Exit(1);



        }
    }
}
