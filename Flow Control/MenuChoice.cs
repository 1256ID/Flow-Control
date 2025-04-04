using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control;

internal class MenuChoice
{
    public string returnToMenuText = "\n\nKlicka på valfri tangent för att återvänta till menyn...";
    public void One()
    {
        int index = 0;
        bool cinemaIsActive = true;
        int age;



        while (cinemaIsActive)
        {
            Console.Clear();           
            index = Menu.Initialize
                (
                    [
                        "1. Räkna ut pris för en person",
                        "2. Räkna ut pris för grupp",
                        "3. Gå tillbaka till huvudmenyn"
                    ]

                    , index, "Ungdom eller pensionär"
                );


          switch (index)
            {

                case 0:
                    Console.Clear();
                    age = GetNumericalInputFromUser(true);
                    int calculatedPrice = CalculatePricePerPerson(age);
                    Console.WriteLine(GetPriceAsMessage(calculatedPrice));
                    Console.WriteLine(returnToMenuText);
                    Console.ReadLine();
                break;

                case 1:
                    Console.Clear();
                    int totalPrice = 0;
                    Console.Write("Ange hur många ni är: ");
                    Console.Clear();
                    int groupCount = GetNumericalInputFromUser(false);
                    for (int i = 0; i < groupCount; i++)
                    {
                        age = GetNumericalInputFromUser(true);
                        totalPrice += CalculatePricePerPerson(age);
                    }

                    Console.Clear();
                    Console.WriteLine("Antalet personer: " + groupCount);
                    Console.WriteLine(GetPriceAsMessage(totalPrice));
                    Console.WriteLine(returnToMenuText);
                    Console.ReadLine();



                break;

                case 2:
                    cinemaIsActive = false;
                break;
            }






        }
    }

    public void Two()
    {

    }

    public void Three()
    {

    }

    public static int GetNumericalInputFromUser(bool isInputAge)
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
                                    ("Var vänlig och undvik negativa tal\n\n"
                                    + continueText);
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
                            Console.WriteLine
                                ("Var vänlig och försök igen\n\n"
                                + continueText);
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }

                catch
                {
                    Console.WriteLine
                        ("Var vänlig och försök igen\n\n"
                        + continueText);
                    Console.ReadLine();
                    Console.Clear();
                }
            }

        return output;

    }

    public int CalculatePricePerPerson(int age)
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

    public string GetPriceAsMessage (int price)
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
