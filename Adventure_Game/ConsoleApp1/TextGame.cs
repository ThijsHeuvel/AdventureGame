using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Classes;

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
                Console.WriteLine("2. Load Game\n\n");
            }

            string userInput = Helper.AskInput("Keuze:");
            switch (userInput)
            {
                case "1":
                    // Method for starting new game
                    break;
                case "2":
                    // Method for loading a game IF ONE EXISTS.
                    if (!File.Exists($"{dirPath}\\save.txt"))
                    {
                        Helper.WaitForInput("Invalid Choice. Try again.");
                        Console.Clear();
                        MainMenu();
                        break;
                    }
                    Console.WriteLine("Save File Found!");
                    break;
                default:
                    Helper.WaitForInput("Invalid Choice. Try again.");
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
    }
}
