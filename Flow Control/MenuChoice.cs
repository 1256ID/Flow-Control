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
     
        Metoden CalculateTicketPrice() har samma struktur som Main metoden 
        då den också använder sig av 'Display()' och en switch-statement.

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
