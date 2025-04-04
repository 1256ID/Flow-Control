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
                    age = AppUtilities.PromptUserForNumericalInput(true);
                    int calculatedPrice = AppUtilities.CalculatePricePerPerson(age);
                    Console.WriteLine(AppUtilities.GetPriceAsMessage(calculatedPrice));
                    Console.WriteLine(returnToMenuText);
                    Console.ReadLine();
                break;

                case 1:
                    Console.Clear();
                    int totalPrice = 0;
                    Console.Write("Ange hur många ni är: ");
                    Console.Clear();
                    int groupCount = AppUtilities.PromptUserForNumericalInput(false);
                    for (int i = 0; i < groupCount; i++)
                    {
                        age = AppUtilities.PromptUserForNumericalInput(true);
                        totalPrice += AppUtilities.CalculatePricePerPerson(age);
                    }

                    Console.Clear();
                    Console.WriteLine("Antalet personer: " + groupCount);
                    Console.WriteLine(AppUtilities.GetPriceAsMessage(totalPrice));
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
        string input = AppUtilities.PromptUserForTextInput();
        Console.Clear();

        for (int i = 1; i <= 10; i++)
        {
            Console.Write(i + ". " + input + " ");
        }

        Console.WriteLine("\n\n" + returnToMenuText);
        Console.ReadLine();
    }

    public void Three()
    {
        string input = AppUtilities.PromptUserForTextInput();


    }

  
}
