using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class TextGame
    {
        string? dirPath;
        internal void Run() // Gets called when the program starts in Program.cs.
        {
            dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            MainMenu();
        }

        private void MainMenu() // Shows the main menu of the application
        {
            Console.WriteLine("Welcome to AdventureGame!");
            Console.WriteLine("1. New Game");

            if (File.Exists($"{dirPath}\\save.txt"))
            {
                Console.WriteLine("2. Load Game");
            }
        }
    }
}
