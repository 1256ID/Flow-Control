using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace Flow_Control;

// Denna klass innehåller övriga metoder som programmet använder sig av.

internal class AppUtilities
{
    public static string tryAgainText = "Var vänlig och försök igen";
    public static string continueText = "\n\nKlicka på valfri tangent för att fortsätta";

    ////////////////////////////////// Input metoder ////////////////////////////////////
   
    // Prompt metoderna hanterar alla user-inputs och innehåller
    // även felhantering som används ifall något går snett.
  
    public static int PromptUserForNumericalInput(bool inputIsAge)
    {
        int output = 0;
        bool waitingForCorrectInput = true;
        
        string attributeName = "ålder";
        if (!inputIsAge)
        {
            attributeName = "antalet personer";
        }
       
        while (waitingForCorrectInput)
        {
            try
            {
                Console.Write("Var vänlig och fyll i " + attributeName + ": ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine
                        ("Var vänlig och använd siffor för att ange " + 
                        attributeName +  continueText);
                    Console.ReadLine();
                    Console.Clear();
                }

                else
                {
                    bool validInput = int.TryParse(input, out output);
                    if (validInput)
                    {
                        if (output < 0)
                        {
                            Console.WriteLine
                                ("Var vänlig och undvik negativa tal" + continueText);
                            Console.ReadLine();
                            Console.Clear();
                        }

                        else
                        {
                            waitingForCorrectInput = false;
                        }
                    }

                    else
                    {
                        Console.WriteLine(tryAgainText + continueText);
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }

            catch
            {
                Console.WriteLine(tryAgainText + continueText);
                Console.ReadLine();
                Console.Clear();
            }
        }

        return output;

    }

    public static string PromptUserForTextInput()
    {
        string output = "";
        bool waitingForCorrectInput = true;

        while (waitingForCorrectInput)
        {           
            try
            {
                Console.Clear();
                Console.Write("Skriv in valfri text: ");
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Inmatningen får inte vara tom\n\n" + tryAgainText);
                    Console.ReadLine();
                }

                else
                {
                    if (input != null)
                    {
                        output = input;
                    }
                    
                    waitingForCorrectInput = false;                     
                }
            }

            catch
            {
                Console.WriteLine("Ogiltig inmatning\n\n" + tryAgainText);
                Console.ReadLine();
            }
        }
             
        return output;
                  
    }

    /////////////////////////////////////////////////////////////////////////////////////
    
    
    ///////////////////////////////////// Menyval 1 /////////////////////////////////////
    
    /* 
        För att följa principen DRY så valde jag att använde
        en metod för att hantera logiken i menyval 1.

        Enda skillnaden mellan valen inom menyval 1 är ju antalet
        den ska kunna ta emot samt att output:en skiljer sig lite.

        Därav så ansåg jag det vore bättre och bara använda 
        en metod som hanterar detta.
        
        Nackdelen däremot är ju att metoden är beroende av input
        boolean 'InGroup' för att den ska fungera rätt.
    */

    public static void CalculateTicketPrice(bool InGroup)
    {
        Console.Clear();
        int groupCount = 1;
        int totalPrice = 0;
        int age = 0;
        if (InGroup)
        {
            Console.Write("Ange hur många ni är: ");
            Console.Clear();
            groupCount = PromptUserForNumericalInput(false);
        }
     
        for (int i = 0; i < groupCount; i++)
        {
            age = PromptUserForNumericalInput(true);
            totalPrice += GetPrice(age);

        }

        Console.Clear();
        if (InGroup)
        {
            Console.WriteLine("Antalet personer: " + groupCount);
        }
     
        Console.WriteLine(GetOutputFromPrice(totalPrice));
        Console.WriteLine(MenuChoice.returnToMenuText);
        Console.ReadLine();
    }

    // Returnerar pris baserat på ålder.

    public static int GetPrice(int age)
    {
        if (age < 5 || age > 100) 
        { 
            return 0; 
        }

        if (age < 20)
        {
            return 80;
        }

        else if (age > 64)
        {
            return 90;
        }

        else
        {
            return 120;
        }
    }

    // Returnerar meddelandet/output message baserat på pris.
    public static string GetOutputFromPrice(int price)
    {
        if (price == 0)
        {
            return "Barn under fem och pensionärer över 100 går gratis.";
        }
        else if (price == 80)
        {
            return "Ungdomspris: " + price;
        }

        else if (price == 90)
        {
            return "Pensionärspris: " + price;
        }

        else if (price == 120)
        {
            return "Standardpris: " + price;
        }

        else
        {
            return "Total kostnad: " + price;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////

    // Tar bort mellanslag i början och slutet av input-strängen.
    public static string RemoveFirstAndLastSpace (string input)
    {
        string output = "";
        int firstOccurensOfLetter = 0, 
            lastOccurensOfLetter = input.Length - 1;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != ' ')
            {
                if (i != 0)
                {
                    firstOccurensOfLetter = i;
                    break;
                }     
            }
        }

        for (int j = input.Length - 1; j >= 0; j--)
        {
            if (input[j] != ' ')
            {                                 
                lastOccurensOfLetter = j;
                break;
                             
            }
        }        

        int newStringLength = lastOccurensOfLetter - firstOccurensOfLetter + 1;
        output = input.Substring(firstOccurensOfLetter, newStringLength);

        return output;
    }

    // Kollar ifall det existerar mer än ett mellanslag mellan orden/strängarna.
    // Om detta är sant så sparas bara ett mellanslag mellan orden i den output
    // strängen.

    public static string RemoveWhereSpaceOccursMoreThanOnce(string input)
    {
        string output = Convert.ToString(input[0]);
        
        for (int i = 1; i < input.Length; i++)
        {        
            if ((input[i] == ' ') && (input[i - 1] == ' ')) 
            {
                continue;
            }

            output += input[i];
        }

        return output;
        
    }

    // Bara en extra funktion, gör så att ett ljud spelas upp när piltangenterna
    // används för att navigera i menyn.

    public static void PlayMenuSound()
    {        
        string currentDir = AppDomain.CurrentDomain.BaseDirectory;
        string repoRoot = currentDir.Contains(@"\bin\")
            ? currentDir[..currentDir.IndexOf(@"\bin\")]
            : currentDir;

        string soundPath = Path.Combine(repoRoot, "sound", "click_sound.wav");

        if (File.Exists(soundPath))
        {
            SoundPlayer player = new SoundPlayer(soundPath);
            player.Play(); 
        }
    }


}
