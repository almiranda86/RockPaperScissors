using RockPaperScissors.Core;
using RockPaperScissors.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Application
{
    public static class Screen
    {
        internal static string PrintWellCome()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                     =========================================================================");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |           {GameMessagesConstants.WellcomeMessage}             |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |                    {GameMessagesConstants.GameMode}                     |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |                   {GameMessagesConstants.P1vsP2}                    |");
            _sb.AppendLine($"                     |                     {GameMessagesConstants.P1vsCPU}                       |");
            _sb.AppendLine($"                     |                       {GameMessagesConstants.GameOptions}                        |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     =========================================================================");


            return _sb.ToString();
        }

        internal static string GameMode(string key2)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                     =========================================================================");
            _sb.AppendLine($"                     |                                                                       |");
            if (key2.Equals(Constants.CPU))
            {
                _sb.AppendLine($"                     |                  {GameMessagesConstants.GameModeP1vsCPU}                     |");
            }
            else
            {
                _sb.AppendLine($"                     |                  {GameMessagesConstants.GameModeP1vsPlayer2}              |");
            }

            _sb.AppendLine(Explanation());
            _sb.AppendLine($"                     =========================================================================");

            return _sb.ToString();
        }

        private static string Explanation()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine($"                     |           {GameMessagesConstants.ExplainRules}         |");
            _sb.AppendLine($"                     |                  {GameMessagesConstants.ExplainRules1}                   |");
            _sb.AppendLine($"                     |                           {GameMessagesConstants.Motivational}                          |");


            return _sb.ToString();
        }

        internal static string PlayerSelect(int player)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            if (player == 1)
            {
                _sb.AppendLine($"       {GameMessagesConstants.Player1SelectOption}");
            }
            else
            {
                _sb.AppendLine($"       {GameMessagesConstants.Player2SelectOption}");
            }


            return _sb.ToString();
        }

        internal static string SelectOption(Setup options)
        {
            StringBuilder _sb = new StringBuilder();

            for (int i = 0; i < options.GameOptions.Count(); i++)
            {
                _sb.AppendLine($"       {options.GameOptions.Options[i].key}: {options.GameOptions.Options[i].value}");
            }

            return _sb.ToString();
        }

        internal static string CPU_Turn()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine(GameMessagesConstants.NewLine);
            _sb.AppendLine($"       {GameMessagesConstants.CPU_Turn}");
            return _sb.ToString();
        }

        internal static string CPU_Decision()
        {
            System.Threading.Thread.Sleep(2000);
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"       {GameMessagesConstants.CPUDecided}");
            return _sb.ToString();
        }

        internal static string Jan()
        {
            System.Threading.Thread.Sleep(1000);
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {GameMessagesConstants.JAN}");

            return _sb.ToString();
        }

        internal static string Ken()
        {
            System.Threading.Thread.Sleep(1000);
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"       {GameMessagesConstants.KEN}");
            return _sb.ToString();
        }

        internal static string Pon()
        {
            System.Threading.Thread.Sleep(1000);
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"       {GameMessagesConstants.PON}");

            return _sb.ToString();
        }

        internal static void ClearScreenAfterSeconds(int time)
        {
            System.Threading.Thread.Sleep(time);
            ClearScreen();
        }

        internal static void ClearScreen()
        {
            Console.Clear();
        }

        private static string HeadSpaces()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine(GameMessagesConstants.NewLine);
            _sb.AppendLine(GameMessagesConstants.NewLine);
            return _sb.ToString();
        }

        internal static string ResultRoundDraw()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                     =========================================================================");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |                {GameMessagesConstants.RoundDraw}               |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |                         {GameMessagesConstants.Reboot}                        |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     =========================================================================");


            return _sb.ToString();
        }

        internal static string ResultRoundLose(string value1, string value2)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                                           {GameMessagesConstants.Player2_WonRound}");
            _sb.AppendLine($"                                                                                            ");
            _sb.AppendLine($"                                         {String.Format(GameMessagesConstants.RoundOptionInformation, value1, value2)}");
            _sb.AppendLine($"                                                                                            ");
            _sb.AppendLine($"                                                   {GameMessagesConstants.TryAgain}");
            return _sb.ToString();
        }

        internal static string ResultRoundWin(string value1, string value2)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                                                {GameMessagesConstants.Player_WonRound}");
            _sb.AppendLine($"                                                                                            ");
            _sb.AppendLine($"                                           {String.Format(GameMessagesConstants.RoundOptionInformation, value1, value2)}");
            _sb.AppendLine($"                                                                                            ");
            _sb.AppendLine($"                                                    {GameMessagesConstants.TryAgain}");
            return _sb.ToString();
        }

        internal static string Score(Dictionary<string, int> score, string key2 = default(string))
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                     =========================================================================");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |           {GameMessagesConstants.Score}                                                      |");
            _sb.AppendLine($"                     |                                                                       |");
            if (key2 != null && key2 != string.Empty && key2.Equals(Constants.CPU))
            {
                _sb.AppendLine($"                     |           {String.Format(GameMessagesConstants.ScoreResult, score[Constants.Player1], score[key2])}                                          | ");
            }
            else
            {
                _sb.AppendLine($"                     |           {String.Format(GameMessagesConstants.ScoreResultPvP, score[Constants.Player1], score[Constants.Player2])}                                   | ");
            }
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     =========================================================================");


            return _sb.ToString();
        }

        internal static string YouWon()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                     =========================================================================");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |           {GameMessagesConstants.PlayerWonGame}             |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     =========================================================================");


            return _sb.ToString();
        }

        internal static string YouLose()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                     =========================================================================");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |           {GameMessagesConstants.Player2WonGame }             |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     =========================================================================");


            return _sb.ToString();
        }

        internal static string DificultyLevel()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                     =========================================================================");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |                   {GameMessagesConstants.DifficultLevel}                        |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |                        {GameMessagesConstants.EASY} || {GameMessagesConstants.HARD}                             |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     =========================================================================");


            return _sb.ToString();
        }

        internal static string Options()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"                     =========================================================================");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     |                   {GameMessagesConstants.MoreOptions}            |");
            _sb.AppendLine($"                     |                        {GameMessagesConstants.EditOptions}                  |");
            _sb.AppendLine($"                     |                             {GameMessagesConstants.RuleOptions}                         |");
            _sb.AppendLine($"                     |                           {GameMessagesConstants.Back}                        |");
            _sb.AppendLine($"                     |                                                                       |");
            _sb.AppendLine($"                     =========================================================================");


            return _sb.ToString();
        }

        internal static string TotalNewOptions()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {GameMessagesConstants.TotalNewOptions}");
            return _sb.ToString();
        }

        internal static string AvailableOptions(Setup options)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {GameMessagesConstants.AvailableOptions}");
            _sb.AppendLine($"{ SelectOption(options)}");
            return _sb.ToString();
        }

        internal static string NumberNewOptions(int total)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {String.Format(GameMessagesConstants.NumberOptions, total)}");
            return _sb.ToString();
        }

        internal static string NameNewOptions()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {GameMessagesConstants.NewOptionName}");
            return _sb.ToString();
        }

        internal static string NewOptionsDefeatWhat()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {GameMessagesConstants.NewOptionDefeatWhat}");
            return _sb.ToString();
        }

        internal static string WaitUntilTheGameUpdate()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {GameMessagesConstants.WaitUntilUpdate}");
            return _sb.ToString();
        }

        internal static string GameUpdated()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {GameMessagesConstants.GameUpdated}");
            return _sb.ToString();
        }

        internal static string WhichOptionEdit()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {GameMessagesConstants.AtentionEdit}");
            _sb.AppendLine($"       {GameMessagesConstants.WhichOptionEdit}");
            return _sb.ToString();
        }

        internal static string ChosenEditOptions(string optionName)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {String.Format(GameMessagesConstants.ChosenOption, optionName)}");
            return _sb.ToString();
        }

        internal static string DefeatsOption(string optionName)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {String.Format(GameMessagesConstants.DefeatedOption, optionName)}");
            return _sb.ToString();
        }

        internal static string NewDefeatedOption()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {String.Format(GameMessagesConstants.NewDefeatedOption)}");
            return _sb.ToString();
        }

        internal static string AvailableEditOptions(List<Options> optionsAvailable)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {GameMessagesConstants.AvailableOptions}");
            _sb.AppendLine($"{ SelectOption(optionsAvailable)}");
            return _sb.ToString();
        }

        internal static string SelectOption(List<Options> optionsAvailable)
        {
            StringBuilder _sb = new StringBuilder();

            for (int i = 0; i < optionsAvailable.Count; i++)
            {
                _sb.AppendLine($"       {optionsAvailable[i].key}: {optionsAvailable[i].value}");
            }

            return _sb.ToString();
        }

        internal static string TradeMenu()
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendLine($"       {String.Format(GameMessagesConstants.ForTrade)}");
            _sb.AppendLine($"       {String.Format(GameMessagesConstants.ForAdd)}");
            return _sb.ToString();
        }

        internal static string AddNewDefeatedOption()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {String.Format(GameMessagesConstants.AddNewDefeatedOption)}");
            return _sb.ToString();
        }

        internal static string GameRules()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine(HeadSpaces());
            _sb.AppendLine($"       {String.Format(GameMessagesConstants.GameRules)}");
            return _sb.ToString();
        }

        internal static string OptionDefeatOption(string option1, string option2)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"       {String.Format(GameMessagesConstants.OptionDefeatOption, option1, option2)}");
            return _sb.ToString();
        }
    }
}
