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


            if (index == 0)
            {

            }

            else if (index == 1)
            {

            }


            else
            {

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

}
