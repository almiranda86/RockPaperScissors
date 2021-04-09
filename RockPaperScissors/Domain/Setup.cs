using RockPaperScissors.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Domain
{
    public class Setup
    {
        private int Key { get; set; }
        private string Value { get; set; }

        public GameOptions GameOptions = new GameOptions();

        int options = 3;

        public Setup()
        {

        }

        public void SetupGame()
        {
            GameOptions.Options = new List<Options>();

            for (int i = 0; i < options; i++)
            {
                GameOptions.AddLast(Config.OPTIONS[i], i + 1);
            }

            SetDefaulCoreRule();
        }


        private void SetDefaulCoreRule()
        {
            for (int i = 0; i < GameOptions.Options.Count; i++)
            {
                if (GameOptions.Options[i].key == 1)
                {
                    GameOptions.Options[i].defeats.Add(3, Config.SCISSOR);
                }
                else
                if (GameOptions.Options[i].key == 2)
                {
                    GameOptions.Options[i].defeats.Add(1, Config.ROCK);
                }
                else
                if (GameOptions.Options[i].key == 3)
                {
                    GameOptions.Options[i].defeats.Add(2, Config.PAPER);
                }
            }
        }

        internal void SetupNewOption(string nameOption, int defeatOption)
        {
            GameOptions.AddNewOption(nameOption, defeatOption);
        }

        internal Options SetupRetrieveOptionNameByKey(int numberOption)
        {
            return GameOptions.FindOptionByKey(numberOption);
        }

        internal void SetupNewDefeatOption(int chosenOption, int newDefeatOption, bool isAddNew = false)
        {
            if (isAddNew)
            {
                GameOptions.UpdateDefeatOption(chosenOption, newDefeatOption, isAddNew);
            }
            else
            {
                GameOptions.UpdateDefeatOption(chosenOption, newDefeatOption);
            }
        }

        internal List<Options> ListGameOptions()
        {
            return GameOptions.ListOptions();
        }
    }
}
