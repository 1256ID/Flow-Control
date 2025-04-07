namespace Flow_Control;

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

            // 'Display()' används för att både visa men också hantera menyns logik.

            index = Menu.Display
            (
                [
                    "1. Ungdom eller pensionär",
                    "2. Iterera inmatning 10 gånger",
                    "3. Skriv ut tredje ordet i en mening",
                    "4. Avsluta program"

                ], index, "Huvudmeny"
            );

            /* 
                Ett switch-statement som använder sig av returnerings värdet
                från 'Display()' för att avgöra vilket case som ska väljas.

                Samtliga cases anropar det nedanstående metoderna som 
                i sin del hanterar menyvalens logik.

                - CalculateTicketPrice(), 
                - PrintInput_OnTheSameLine_TenTimes() 
                - PrintTheThirdWord() 
                
                Case 3 används för att avsluta programmet men istället för att 
                lägga en 'Enviroment.Exit' i case:t så använder jag mig bara av
                bool:en 'programIsRunning' som håller igång while-loop:en för 
                att avsluta programmet då en 'Enviroment.Exit' ligger nedanför
                loop:en.
                
                Jag har gjort detta för att jag tycker att det tydliggör vad 'case 3' gör.
                             
                Eftersom att menyn använder sig av en array för visa menyn
                så har jag valt att lägga menyvalet längst ned pga indexering.

                Hantering av felaktig input hanteras i metoden Display()
            */

            switch (index)
            {
                case 0:
                    MenuChoice.CalculateTicketPrice();
                    break;
                case 1:
                    MenuChoice.PrintInput_OnTheSameLine_TenTimes();
                    break;

                case 2:
                    MenuChoice.PrintTheThirdWord();
                    break;

                case 3:
                    programIsRunning = false;
                    break;
            };
        }

        Environment.Exit(0);

    }
}
