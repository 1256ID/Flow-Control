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
                (
                    "Du har nu kommit fram till huvudmenyn\n\n" +
                    "Använd piltangenterna för att navigera i menyn och ENTER för att välja ett val\n\n" +
                    "Klicka på valfri tangent för att fortsätta till huvudmenyn..."
                );

            Console.ReadLine();

            while (programIsRunning)
            {
                Console.Clear();                           
                index = Menu.Initialize
                (
                    [
                        "1. Ungdom eller pensionär",
                        "2. Menyval 2",
                        "3. Menyval 3",
                        "4. Avsluta program"

                    ], index, "Huvudmeny"
                );
               

                /* 
                En switch-statement som hanterar samtliga menyval
                Samtliga cases anropar metoden One(), Two() och Three() som hanterar menyvalens logik. 

                Eftersom att jag använder mig av en array för visa menyn
                så har jag valt att lägga menyvalet längst ned pga indexering.

                Hantering av felaktig input hanteras i metoden "Initialize()"
                */

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

            Environment.Exit(0);

        }
    }
}
