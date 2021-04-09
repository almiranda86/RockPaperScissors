using RockPaperScissors.Core;
using RockPaperScissors.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Application
{
    public class GameEngine
    {
        public static Dictionary<string, int> score = new Dictionary<string, int>();
        static Random random = new Random();
        static int cpuOption = 0;
        GameControlModel GameControl;
        public GameEngine()
        {
            score.Add(Constants.Player1, 0);
            score.Add(Constants.Player2, 0);
            score.Add(Constants.CPU, 0);
            GameControl = new GameControlModel();
        }

        public GameControlModel PlayerVsCPU(int playerOption, Setup setup, int difficultyLevel = 0)
        {
            if (cpuOption == 0)
            {
                cpuOption = random.Next(1, setup.GameOptions.Count());
            }
            
            
            if (difficultyLevel == 1)
            {
                var cpuLastOption = setup.GameOptions.FindOptionThatDefeatsByKey(cpuOption);

                cpuOption = cpuLastOption.key;
            }
            else
            {
                cpuOption = random.Next(1, setup.GameOptions.Count());
            }

            GameControl.Player1Option = setup.GameOptions.FindOptionNameByKey(playerOption);
            GameControl.Player2Option = setup.GameOptions.FindOptionNameByKey(cpuOption);
            GameControl.RoundResult = CoreRule(playerOption, cpuOption, Constants.CPU, setup);
            GameControl.Score = score;

            return GameControl;
        }

        public GameControlModel PlayerVsPlayer(int player1Option, int player2Option, Setup setup)
        {
            GameControl.Player1Option = setup.GameOptions.FindOptionNameByKey(player1Option);
            GameControl.Player2Option = setup.GameOptions.FindOptionNameByKey(player2Option);
            GameControl.RoundResult = CoreRule(player1Option, player2Option, Constants.Player2);
            GameControl.Score = score;

            return GameControl;
        }


        private int CoreRule(int option1, int option2, string key, Setup setup = null)
        {
            var player1Option = setup.GameOptions.FindOptionByKey(option1);
            var player2Option = setup.GameOptions.FindOptionByKey(option2);

            if (player1Option.key == player2Option.key)
            {
                score[Constants.Player1] = 0;
                score[key] = 0;
                return 0;
            }

            if (player1Option.defeats.ContainsKey(option2))
            {
                score[Constants.Player1] += 1;
                return 2;
            }
            else if (player2Option.defeats.ContainsKey(option1))
            {
                score[key] += 1;
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public bool EndGame(string key1, string key2)
        {
            return score[key1] != 3 && score[key2] != 3;
        }
    }
}
