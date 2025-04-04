using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control;

internal class Menu
{
    public static int Initialize(string[] arr, int index, string menuTitle)
    {
        bool indexIsChosen = false;

        int maxAmountOfChars = arr.Max(arr => arr.Length) + 7;
        string menuOutliners = "";

        for (int i = 0; i< maxAmountOfChars; i++)
        {
            menuOutliners += "*";
        }


        while (!indexIsChosen)
        {
            Console.Clear();
            Console.WriteLine(menuTitle + "\n");
            Console.WriteLine(menuOutliners);

            for (int i = 0; i < arr.Length; i++)
            {

                string output = arr[i];

                if (i == index)
                {
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write(arr[i]);

                Console.ResetColor();

                if (i == index)
                {
                    Console.Write(" <---");
                }

                Console.Write("\n");
            }

            Console.WriteLine(menuOutliners);

            // Läser in input från användare

            ConsoleKeyInfo input = Console.ReadKey();

            // Justerar index efter vilken piltangent som används eller ifall användaren väljer att gå vidare

            switch (input.Key)
            {

                case ConsoleKey.UpArrow:
                    if (index != 0)
                    {
                        index--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (index < arr.Length - 1)
                    {
                        index++;
                    }
                    break;

                case ConsoleKey.Enter:
                    if (index < arr.Length)
                    {
                        indexIsChosen = true;
                    }
                    break;


                default:
                    Console.Clear();
                    Console.WriteLine
                        (
                            "Felaktiga tangenter har använts, var vänlig och använd " +
                            " piltangenterna och ENTER för att bekräfta ett val.\n\n" +
                            "Klicka på valfri tangent för att fortsätta..."
                        );
                    Console.ReadLine();
                    break;
            }         
        }

        return index;
    }
}
