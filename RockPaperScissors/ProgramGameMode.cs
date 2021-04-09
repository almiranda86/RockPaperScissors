using RockPaperScissors.Application;
using RockPaperScissors.Core;
using RockPaperScissors.Domain;
using System;

namespace RockPaperScissors
{
    partial class Program
    {
        static void GameMode(string key1, string key2)
        {
            GameEngine gameEngine = new GameEngine();
            GameControlModel gameResult = new GameControlModel();
            int difficultyLevel = 0;

            Screen.ClearScreen();

            Console.WriteLine(Screen.GameMode(key2));

            Screen.ClearScreenAfterSeconds(5000);

            if (key2.Equals(Constants.CPU))
            {
                Console.WriteLine(Screen.DificultyLevel());
                var level = Console.ReadKey();

                if (Util.KeyIsDigit(level.KeyChar))
                {
                    difficultyLevel = Util.KeyCharToInt(level.KeyChar);
                }
            }

            Screen.ClearScreen();

            while (gameEngine.EndGame(key1, key2))
            {
                Console.WriteLine(Screen.PlayerSelect(1));
                Console.WriteLine(Screen.SelectOption(setup));
                var selectedOption = Console.ReadKey();
                int player1Option = 0;
                int player2Option = 0;

                if (Util.KeyIsDigit(selectedOption.KeyChar))
                {
                    player1Option = Util.KeyCharToInt(selectedOption.KeyChar);
                }

                Screen.ClearScreen();

                if (key2.Equals(Constants.CPU))
                {
                    Console.WriteLine(Screen.CPU_Turn());
                    Console.WriteLine(Screen.CPU_Decision());
                }
                else
                {
                    Console.WriteLine(Screen.PlayerSelect(2));
                    Console.WriteLine(Screen.SelectOption(setup));
                    selectedOption = Console.ReadKey();

                    if (Util.KeyIsDigit(selectedOption.KeyChar))
                    {
                        player2Option = Util.KeyCharToInt(selectedOption.KeyChar);
                    }

                    Screen.ClearScreen();
                }

                Screen.ClearScreenAfterSeconds(3000);

                Console.WriteLine(Screen.Jan());
                Console.WriteLine(Screen.Ken());
                Console.WriteLine(Screen.Pon());

                Screen.ClearScreen();

                if (key2.Equals(Constants.CPU))
                {
                    gameResult = gameEngine.PlayerVsCPU(player1Option, setup, difficultyLevel);
                }
                else
                {
                    gameResult = gameEngine.PlayerVsPlayer(player1Option, player2Option, setup);
                }

                if (gameResult.RoundResult == 0)
                {
                    Console.WriteLine(Screen.ResultRoundDraw());
                }
                else if (gameResult.RoundResult == 1)
                {
                    Console.WriteLine(Screen.ResultRoundLose(gameResult.Player1Option, gameResult.Player2Option));
                }
                else if (gameResult.RoundResult == 2)
                {
                    Console.WriteLine(Screen.ResultRoundWin(gameResult.Player1Option, gameResult.Player2Option));
                }
                else
                {
                    Console.WriteLine(GameMessagesConstants.OptionIsntAvailable);
                }

                Screen.ClearScreenAfterSeconds(5000);

                if (key2.Equals(Constants.CPU))
                {
                    Console.WriteLine(Screen.Score(gameResult.Score, Constants.CPU));
                }
                else
                {
                    Console.WriteLine(Screen.Score(gameResult.Score));
                }

                Screen.ClearScreenAfterSeconds(2000);
            }

            if (gameResult.Score[key1] == 3)
            {
                Console.WriteLine(Screen.YouWon());
            }
            else if (gameResult.Score[key2] == 3)
            {
                Console.WriteLine(Screen.YouLose());
            }
        }
    }
}

