﻿using System;
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
        Player player = new Player();
        CaseLoader caseLoader;

        public TextGame()
        {
            caseLoader = new CaseLoader(this);
        }
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
                    Console.Clear();
                    // Method for starting new game
                    if (File.Exists($"{dirPath}\\save.txt"))
                    {
                        string answer = Helper.AskInput("WARNING!!\nIf you start a new game, your save file will be reset.\nAre you sure you want to continue?\n\n[Y/N]\n\n");
                        answer = answer.ToLower();
                        if (answer == "n")
                        {
                            Console.Clear();
                            MainMenu();
                        }
                    }
                    NewGame();
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
                    LoadGame();
                    break;
                default:
                    Helper.WaitForInput("Invalid Choice. Try again.");
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }

        private void NewGame() // Creates/Replaces a new save file and saves the default player stats to it
        {
            Console.Clear();
            player.CaseID = 010;
            player.HintsLeft = 2;
            if (File.Exists($"{dirPath}\\save.txt"))
            {
                File.Delete($"{dirPath}\\save.txt");
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter("save.txt");
            file.WriteLine(player.CaseID + "\n" + player.HintsLeft);
            file.Close();
            caseLoader.LoadCase(player.CaseID, player.HintsLeft);
        
        }

        private void LoadGame() // This checks if the save file is valid by seeing if the first value can be a valid integer. If so, save the values to the application.
        {
            Console.Clear();
            
            if (!int.TryParse(Helper.GetSaveLine(1), out int caseID))
            {
                Console.WriteLine("Save File Invalid. Possibly corrupt?");
                MainMenu();
            }
            int hintsLeft = int.Parse(Helper.GetSaveLine(2));
            player.CaseID = caseID;
            player.HintsLeft = hintsLeft;
            caseLoader.LoadCase(player.CaseID, player.HintsLeft);
        }

        public void SaveAndQuit(int caseId, int hintsLeft) // This saves the parameters to the save file, and force quits the game with code 0.
        {
            Console.Clear();
            System.IO.StreamWriter file = new System.IO.StreamWriter("save.txt");
            file.WriteLine(caseId + "\n" + hintsLeft);
            file.Close();
            Helper.WaitForInput("Your progress has been saved. Thanks for playing!");
            Environment.Exit(0);
        }

        public bool RemoveHint() // Removes a hint if possible. If not, return false
        {
            if (player.HintsLeft > 0)
            {
                player.HintsLeft = player.HintsLeft - 1;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
