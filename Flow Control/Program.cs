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
                index = Menu.Display
                (
                    [
                        "1. Ungdom eller pensionär",
                        "2. Iterera inmatning 10 gånger",
                        "3. Skriv ut sista ordet",
                        "4. Avsluta program"

                    ], index, "Huvudmeny"
                );
               

                /* 
                En switch-statement som hanterar samtliga menyval
                Samtliga cases anropar metoden One(), Two() och Three() som i sin del hanterar menyvalens logik. 

                Eftersom att menyn använder sig av en array för visa menyn
                så har jag valt att lägga menyvalet längst ned pga indexering.

                Hantering av felaktig input hanteras i metoden Display()
                */

                switch (index)
                {
                    case 0:
                        MenuChoice.One();
                        break;
                    case 1:
                        MenuChoice.Two();
                        break;

                    case 2:
                        MenuChoice.Three();
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
