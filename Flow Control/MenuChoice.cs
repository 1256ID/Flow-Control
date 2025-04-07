using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control;

// Denna klass innehåller att logik för själva menyvalen i menyn.

internal class MenuChoice
{
    public static string returnToMenuText = "\n\nKlicka på valfri tangent för att återvänta till menyn...";

    /*
     
        Metoden CalculateTicketPrice() följer samma struktur som Main metoden 
        och fungerar i princip på samma sätt med skillnaden att annourlunda
        metoder anropas.

    */

    public static void CalculateTicketPrice()
    {
        int index = 0;
        bool cinemaIsActive = true;

        while (cinemaIsActive)
        {
            Console.Clear();           
            index = Menu.Display
                (
                    [
                        "1. Räkna ut pris för en person",
                        "2. Räkna ut pris för grupp",
                        "3. Gå tillbaka till huvudmenyn"

                    ], index, "Ungdom eller pensionär"
                );

          switch (index)
            {
                case 0:
                    AppUtilities.CalculateTicketPrice(false);
                break;

                case 1:
                    AppUtilities.CalculateTicketPrice(true);
                break;

                case 2:
                    cinemaIsActive = false;
                break;
            }
        }
    }

    /* 
        Menyval 2 - 3

        Eftersom att det inte krävs särskilt mycket kod för dessa menyval så 
        har jag valt att lägga större delar av logiken inuti dessa metoder.

        Med undantag menyval 3 där jag ansåg att en del logik kunde flyttas 
        ut till class:en AppUtilities.
        
        **** Menyval 2 ****

        Denna metod använder sig av min 'Prompt' metod för att ta emot en
        input från användaren som sedan skrivs ut med en Console.Write();
        i en for-loop 10 gånger. Jag använder mig även av i och extra text      
        "\n\n" för att få fram förväntad output.
        
    */
    public static void PrintInput_OnTheSameLine_TenTimes()
    {
        string input = AppUtilities.PromptUserForTextInput();
        Console.Clear();

        for (int i = 1; i <= 10; i++)
        {
            Console.Write(i + ". " + input + " ");
        }

        Console.WriteLine("\n\n" + returnToMenuText);
        Console.ReadLine();
    }


    /*
        **** Menyval 3 ****
        
        I denna metod används först 'Prompt' metoden för att ta in
        en sträng från användaren. Strängen i sig går sedan igenom
        metoderna 

        - RemoveFirstAndLastSpace()
        - RemoveWhereSpaceOccursMoreThanOnce()

        För att ta bort övriga mellanslag.

        Metoden kollar sedan ifall input är lika med eller längre
        än tre ord. Om inte så får användaren default output från
        metoden vilket tilldelas i början av metoden.

        Annars så tar tilldelas tredje ordet/strängen till output 
        och användaren får se vad tredje ordet är.

     
    */

    public static void PrintTheThirdWord()
    {
        string outputMessage = "Var vänlig och skriv in en mening, använd minst 3 ord.";
        var input = AppUtilities.PromptUserForTextInput();
        input = AppUtilities.RemoveFirstAndLastSpace(input);
        input = AppUtilities.RemoveWhereSpaceOccursMoreThanOnce(input);
        
        string[] stringArray = input.Split(" ");

        if (stringArray.Length >= 3) 
        {
            outputMessage = stringArray[2];
        }

        Console.WriteLine(outputMessage);
        Console.WriteLine(returnToMenuText);
        Console.ReadLine();
    }
}
