using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control
{
    internal class AppUtilities
    {
        public static string tryAgainText = "Var vänlig och försök igen";
        public static string continueText = "\n\nKlicka på valfri tangent för att fortsätta";

        ////////////////////////////////// Input metoder ////////////////////////////////////
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
        
        
        ///////////////////////////////////// Menyval 2 /////////////////////////////////////


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
                    if (j != input.Length - 1)
                    {
                        lastOccurensOfLetter = j;
                        break;
                    }                 
                }
            }

            int newStringLength = lastOccurensOfLetter - firstOccurensOfLetter;

            output = input.Substring(firstOccurensOfLetter, newStringLength + 1);

            return output;
        }

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


    }
}
