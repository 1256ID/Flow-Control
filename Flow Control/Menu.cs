using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control;

internal class Menu
{
    public static int Initialize(string[] arr, int index)
    {
        bool indexIsChosen = false;

        while (!indexIsChosen)
        {
            for (int i = 0; i < arr.Length;)
            {
                string output = arr[i];
                string arrow = " <---";

                if (i == index)
                {
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.White;
                }

                else
                {

                    Console.ResetColor();
                }

                Console.Write(arr[i]);


            }

            // Läser in input från användare

            ConsoleKeyInfo input = Console.ReadKey();

            // Justerar index efter vilken piltangent som används eller ifall användaren väljer att gå vidare

            if (input.Equals(ConsoleKey.UpArrow))
            {
                if (index != 0)
                {
                    index--;
                }
            }

            else if (input.Equals(ConsoleKey.DownArrow))
            {
                if (index < arr.Length - 1)
                {
                    index++;
                }
            }

            else if (input.Equals(ConsoleKey.Enter))
            {
                if (index < arr.Length - 1)
                {
                    index = -2;
                }
            }


            


        }

        return index;
    }
}
