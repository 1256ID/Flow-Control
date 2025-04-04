using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control
{
    internal class AppUtilities
    {
        public static string tryAgainText = "Var vänlig och försök igen\n\n";
        public static int PromptUserForNumericalInput(bool isInputAge)
        {
            int output = 0;
            bool waitingForCorrectInput = true;
            string continueText = "Klicka på valfri tangent för att fortsätta";
            string attributeName = "";
            if (isInputAge)
            {
                attributeName = "ålder";
            }
            else
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
                            ("Var vänlig och använd siffor för att ange " + attributeName + "\n\n"
                            + continueText);
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
                                    ("Var vänlig och undvik negativa tal\n\n" + continueText);
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

        public static int CalculatePricePerPerson(int age)
        {
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

        public static string GetPriceAsMessage(int price)
        {
            if (price == 80)
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
    }
}
