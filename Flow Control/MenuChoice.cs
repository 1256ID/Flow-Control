using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control;

internal class MenuChoice
{
    AppUtilities appUtilities = new AppUtilities();
    public string returnToMenuText = "\n\nKlicka på valfri tangent för att återvänta till menyn...";
    public void One()
    {
        int index = 0;
        bool cinemaIsActive = true;
        int age;

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
                    Console.Clear();
                    age = AppUtilities.GetNumericalInputFromUser(true);
                    int calculatedPrice = appUtilities.CalculatePricePerPerson(age);
                    Console.WriteLine(appUtilities.GetPriceAsMessage(calculatedPrice));
                    Console.WriteLine(returnToMenuText);
                    Console.ReadLine();
                break;

                case 1:
                    Console.Clear();
                    int totalPrice = 0;
                    Console.Write("Ange hur många ni är: ");
                    Console.Clear();
                    int groupCount = AppUtilities.GetNumericalInputFromUser(false);
                    for (int i = 0; i < groupCount; i++)
                    {
                        age = AppUtilities.GetNumericalInputFromUser(true);
                        totalPrice += appUtilities.CalculatePricePerPerson(age);
                    }

                    Console.Clear();
                    Console.WriteLine("Antalet personer: " + groupCount);
                    Console.WriteLine(appUtilities.GetPriceAsMessage(totalPrice));
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

  
}
