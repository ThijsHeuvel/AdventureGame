using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Classes
{
    internal class Helper
    {
        internal static string AskInput(string? question) // Asks for the input of the user with an optional question. Returns non-null value.
        {
            Console.Write(question);
            string? input = Console.ReadLine();
            if (input == null)
            {
                return "";
            }
            else
            {
                return input;
            }
        }

        internal static int AskInt(string? question)
        {
            Console.Write(question);
            string? input = Console.ReadLine();
            int inputInt = 0;
            if (input == null || !int.TryParse(input, out inputInt))
            {
                return inputInt;
            }
            else
            {
                return inputInt;
            }
        }

        internal static void WaitForInput(string? message = null)
        {
            if (message != null && message != "")
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Press any key to continue..");
            }
            Console.ReadKey();
        }
    }
}
