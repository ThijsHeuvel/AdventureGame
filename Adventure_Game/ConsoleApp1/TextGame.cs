using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class TextGame
    {
        internal void Run() // Gets called when the program starts in Program.cs.
        {
            string dirPath = Environment.CurrentDirectory;

            Console.WriteLine("Welcome to AdventureGame!");
            Console.WriteLine("1. New Game");
            // Add if statement to check for Save-Game file

            if (File.Exists($"{dirPath}\\savegame.json"))
            {
                Console.WriteLine("2. Load Game");
            }
        }
    }
}
