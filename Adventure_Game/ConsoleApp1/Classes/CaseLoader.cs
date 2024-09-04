using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Classes
{
    internal class CaseLoader
    {
        int currentCaseID;
        int hintsLeft;

        private TextGame _textGame;
        public CaseLoader(TextGame textGame)
        {
            _textGame = textGame;
        }
        public void LoadCase(int caseIDInput, int hintsLeftInput) // This loads a switch statement with every single option in the game, using the parameters caseID and hintsLeft
        {
            Console.Clear();
            currentCaseID = caseIDInput;
            hintsLeft = hintsLeftInput;
            switch (caseIDInput)
            {
                case 010:
                    Console.WriteLine("You find yourself inside a dark room. You must escape! Find the key to escape. Where will you check for the key?");
                    switch (ValidateCase("1. The Door     2. The Bed\n3. The Cabinet    4. The Toilet", 4, "Where would you usually store items?"))
                    {
                        case 1:
                            LoadCase(011, hintsLeft);
                            break;
                        case 2:
                            LoadCase(012, hintsLeft);
                            break;
                        case 3:
                            LoadCase(020, hintsLeft);
                            break;
                        case 4:
                            LoadCase(014, hintsLeft);
                            break;
                        default:
                            LoadCase(currentCaseID, hintsLeft);
                            break;
                    }
                    break;
                case 011:
                    Console.WriteLine("You go to check the door, but because you don't have the key, it remains locked.");
                    switch (ValidateCase("1. Go back", 1, "Where would you usually store items?"))
                    {
                        case 1:
                            LoadCase(010, hintsLeft);
                            break;
                        default:
                            LoadCase(currentCaseID, hintsLeft);
                            break;
                    }
                    break;
                case 012:
                    Console.WriteLine("You go to check the bed. Here you find a note telling you that you just wasted your time. Guess you should go back then.");
                    switch (ValidateCase("1. Go back", 1, "Where would you usually store items?"))
                    {
                        case 1:
                            LoadCase(010, hintsLeft);
                            break;
                        default:
                            LoadCase(currentCaseID, hintsLeft);
                            break;
                    }
                    break;
                case 014:
                    Console.WriteLine("You notice a toilet in the corner of the room. You go to investigate it, but it seems to be a dead end.");
                    switch (ValidateCase("1. Go back", 1, "Where would you usually store items?"))
                    {
                        case 1:
                            LoadCase(010, hintsLeft);
                            break;
                        default:
                            LoadCase(currentCaseID, hintsLeft);
                            break;
                    }
                    break;
                case 020:
                    Console.WriteLine("You look in the closet, and find the key! You go to open the door, and find yourself in a long hallway with tainted yellow wallpaper.\nYou notice a man standing at the end of the hall. They yell: 'GET OUT OF HERE, NOW!'\nWhat do you do?\n");
                    switch (ValidateCase("1. Run!    2. Negotiate", 2, "If I were you, I would run. Though you could try negotiating as well.."))
                    {
                        case 1:
                            LoadCase(040, hintsLeft);
                            break;
                        case 2:
                            LoadCase(140, hintsLeft);
                            break;
                        default:
                            LoadCase(currentCaseID, hintsLeft);
                            break;
                    }
                    break;
                case 040:
                    Console.WriteLine("You run as fast as you can.. Finally, you find the door leading outside.");
                    if (ValidateCase("1. Open the door!", 1, "Well, there's not much you could do here really.") == 1)
                    {
                        LoadCase(999, hintsLeft);
                    }
                    LoadCase(currentCaseID, hintsLeft);
                    break;
                case 140:
                    Console.WriteLine("'What do you want?' the man says. What will you say to the man?");
                    int caseValidate = ValidateCase("1. I'll give you all my hints!    2. Please dont kill me!", 2, "You better saved up some hints!");
                    if (caseValidate == 1)
                    {
                        if (hintsLeft < 2)
                        {
                            Helper.WaitForInput("You don't have enough hints to give! Game over!");
                            Environment.Exit(0);
                        }
                        hintsLeft = 0;
                        LoadCase(999, hintsLeft);
                    }
                    else if (caseValidate == 2)
                    {
                        Helper.WaitForInput("'Ha, Like that's gonna work!' Game over.");
                        Environment.Exit(0);
                    }
                    LoadCase(currentCaseID, hintsLeft);
                    break;
                case 999:
                    Console.Clear();
                    Helper.WaitForInput($"YOU WIN!!!\nHints left: {hintsLeft}\n\nPress ENTER to close the game!");
                    Environment.Exit(0);
                    break;
                default:
                    Helper.WaitForInput("Missing story case");
                    break;
            }
        }

        private int ValidateCase(string message, int maxInputs, string hint) // This makes sure the user's input is correct, and handles Hints.
        {
            Console.WriteLine(message);

            string answer = Helper.AskInput($"\n\nType in your choice or type 0 for hint ({hintsLeft} left).\nType 'q' to save and quit.\n");
            if (answer.ToLower() == "q")
            {
                _textGame.SaveAndQuit(currentCaseID, hintsLeft);
            }
            if (!int.TryParse(answer, out int answerInt))
            {
                Helper.WaitForInput("Invalid Answer. Try again!");
                Console.Clear();
                ValidateCase(message, maxInputs, hint);
            }

            Console.Clear();
            if (answerInt <= 0)
            {
                if (hintsLeft <= 0)
                {
                    Helper.WaitForInput("No hints left!");
                }
                else
                {
                    hintsLeft = hintsLeft - 1;
                    Helper.WaitForInput(hint);

                }
                LoadCase(currentCaseID, hintsLeft);
                return 0;
            }
            
            if (answerInt > maxInputs)
            {
                Helper.WaitForInput("Invalid Answer. Try again.");
                LoadCase(currentCaseID, hintsLeft);
                return 0;
            }

            return answerInt;

        }
    }
}
