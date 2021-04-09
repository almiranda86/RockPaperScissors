using RockPaperScissors.Application;
using RockPaperScissors.Core;
using RockPaperScissors.Domain;
using System;

namespace RockPaperScissors
{
    partial class Program
    {
        static Setup setup;
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Screen.ClearScreen();

            if(setup == null)
            {
                setup = new Setup();
                setup.SetupGame();
            }         

            Console.WriteLine(Screen.PrintWellCome());

            var gameMode = Console.ReadKey();

            if (Util.KeyIsDigit(gameMode.KeyChar))
            {
                if (Util.KeyCharToInt(gameMode.KeyChar) == 1)
                {
                    GameMode(Constants.Player1, Constants.Player2);
                }
                else if (Util.KeyCharToInt(gameMode.KeyChar) == 2)
                {
                    GameMode(Constants.Player1, Constants.CPU);
                }
                else if (Util.KeyCharToInt(gameMode.KeyChar) == 3)
                {
                    GameOptions();
                }
                else
                {
                    Console.WriteLine(GameMessagesConstants.OptionIsntAvailable);
                }
            }
            else
            {
                Console.WriteLine(GameMessagesConstants.OptionIsntAvailable);
            }
        }
    }
}

