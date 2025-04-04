using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control;

internal class MenuChoice
{
    public void One()
    {
        int index = 0;
        bool cinemaIsActive = true;

        while (cinemaIsActive)
        {
            Console.WriteLine("Biljettförsäljning för bio\n");
            index = Menu.Initialize
                (
                    [
                        "Räkna ut pris för en person",
                        "Räkna ut pris för grupp",
                        "Gå tillbaka till huvudmenyn"
                    ]

                    , index
                );


          switch (index)
            {
                case 0:
                    int age = GetAge();
                    int calculatedPrice = CalculatePricePerPerson(age);
                    string output = GetPriceAsMessage(age);
                    Console.WriteLine(output);
                break;

                case 1:
                    Console.Write("Ange hur många ni är: ");
                    int groupCount;
                    bool 
                    groupCount = int.TryParse(Console.ReadLine(), out groupCount);

                    
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

    public static int GetAge()
    {
        int output = 0;
        bool waitingForCorrectInput = true;
        string continueText = "Klicka på valfri tangent för att fortsätta";

        while (waitingForCorrectInput)
        {
            try
            {
                Console.Write("Var vänlig och fyll i ålder: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine
                        ("Var vänlig och använd siffor för att ange ålder\n\n"
                        + continueText);
                    Console.ReadLine();
                    Console.Clear();
                }

                else
                {
                    bool validInput = int.TryParse(Console.ReadLine(), out output);
                    if (validInput)
                    {
                        if (output < 0)
                        {
                            Console.WriteLine
                                ("Var vänlig och fyll i en giltig ålder\n\n"
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
