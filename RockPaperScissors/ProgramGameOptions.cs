using RockPaperScissors.Application;
using RockPaperScissors.Core;
using RockPaperScissors.Domain;
using System;

namespace RockPaperScissors
{
    partial class Program
    {
        static void GameOptions()
        {
            Screen.ClearScreen();

            Console.WriteLine(Screen.Options());

            var menuOptions = Console.ReadKey();

            if (Util.KeyIsDigit(menuOptions.KeyChar))
            {
                if (Util.KeyCharToInt(menuOptions.KeyChar) == 1)
                {
                    Screen.ClearScreen();

                    Console.WriteLine(Screen.AvailableOptions(setup));

                    Console.WriteLine(Screen.TotalNewOptions());

                    var totalNewOptions = Console.ReadKey();

                    if (Util.KeyIsDigit(totalNewOptions.KeyChar))
                    {
                        Screen.ClearScreen();
                        AddNewOption(Util.KeyCharToInt(totalNewOptions.KeyChar));
                        Screen.ClearScreenAfterSeconds(1000);
                        Console.WriteLine(Screen.WaitUntilTheGameUpdate());
                        Screen.ClearScreenAfterSeconds(3000);
                        Console.WriteLine(Screen.GameUpdated());
                        Console.WriteLine(Screen.AvailableOptions(setup));

                        Screen.ClearScreenAfterSeconds(3000);
                        MainMenu();
                    }

                }
                else if (Util.KeyCharToInt(menuOptions.KeyChar) == 2)
                {
                    Screen.ClearScreen();

                    Console.WriteLine(Screen.AvailableOptions(setup));
                    Console.WriteLine(Screen.WhichOptionEdit());

                    var editOption = Console.ReadKey();

                    if (Util.KeyIsDigit(editOption.KeyChar))
                    {
                        Screen.ClearScreen();

                        EditNewOption(Util.KeyCharToInt(editOption.KeyChar));
                    }
                }else if(Util.KeyCharToInt(menuOptions.KeyChar) == 3)
                {
                    ShowGameRules();
                }
                else if (Util.KeyCharToInt(menuOptions.KeyChar) == 4)
                {
                    MainMenu();
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

        private static void ShowGameRules()
        {
            Screen.ClearScreen();

            var gameOptions = setup.GameOptions.ListOptions();

            Console.WriteLine(Screen.GameRules());

            foreach (var option in gameOptions)
            {
                foreach(var defeats in option.defeats)
                {
                    Console.WriteLine(Screen.OptionDefeatOption(option.value, defeats.Value));
                }
            }

            Screen.ClearScreenAfterSeconds(6000);

            MainMenu();
        }

        static void AddNewOption(int numberOptions)
        {
            Console.WriteLine(Screen.NumberNewOptions(numberOptions));

            for (int i = 0; i < numberOptions; i++)
            {
                Console.WriteLine(Screen.NameNewOptions());
                var newName = Console.ReadLine();

                Console.WriteLine(Screen.NewOptionsDefeatWhat());
                Console.WriteLine(Screen.SelectOption(setup));
                var defeat = Console.ReadKey();

                Screen.ClearScreen();

                setup.SetupNewOption(newName, Util.KeyCharToInt(defeat.KeyChar));
            }
        }


        static void EditNewOption(int numberOption)
        {
            var chosenOption = setup.SetupRetrieveOptionNameByKey(numberOption);

            Console.WriteLine(Screen.ChosenEditOptions(chosenOption.value));

            foreach (var defeated in chosenOption.defeats)
            {
                Console.WriteLine(Screen.DefeatsOption(defeated.Value));
            }

            Console.WriteLine(Screen.TradeMenu());

            var tradeOption = Console.ReadKey();

            if (Util.KeyCharToInt(tradeOption.KeyChar) == 1)
            {
                ModifyDefeatOption(chosenOption, numberOption);
            }
            else if (Util.KeyCharToInt(tradeOption.KeyChar) == 2)
            {
                AddDefeatOption(chosenOption, numberOption);
            }
            else
            {
                Console.WriteLine(GameMessagesConstants.OptionIsntAvailable);
            }
        }

        private static void AddDefeatOption(Options chosenOption, int numberOption)
        {
            Screen.ClearScreen();

            Console.WriteLine(Screen.AddNewDefeatedOption());

            var filteredSetupOptions = setup.GameOptions.FilterOptions(chosenOption.key);

            Console.WriteLine(Screen.AvailableEditOptions(filteredSetupOptions));

            var newDefeat = Console.ReadKey();

            Screen.ClearScreen();

            setup.SetupNewDefeatOption(chosenOption.key, Util.KeyCharToInt(newDefeat.KeyChar), true);

            Screen.ClearScreenAfterSeconds(1000);
            Console.WriteLine(Screen.WaitUntilTheGameUpdate());
            Screen.ClearScreenAfterSeconds(3000);
            Console.WriteLine(Screen.GameUpdated());

            chosenOption = setup.SetupRetrieveOptionNameByKey(numberOption);

            foreach (var defeated in chosenOption.defeats)
            {
                Console.WriteLine(Screen.DefeatsOption(defeated.Value));
            }

            Screen.ClearScreenAfterSeconds(3000);
            MainMenu();
        }

        internal static void ModifyDefeatOption(Options chosenOption, int numberOption)
        {
            Screen.ClearScreen();

            Console.WriteLine(Screen.NewDefeatedOption());

            var filteredSetupOptions = setup.GameOptions.FilterOptions(chosenOption.key);

            Console.WriteLine(Screen.AvailableEditOptions(filteredSetupOptions));

            var newDefeat = Console.ReadKey();

            Screen.ClearScreen();

            setup.SetupNewDefeatOption(chosenOption.key, Util.KeyCharToInt(newDefeat.KeyChar));

            Screen.ClearScreenAfterSeconds(1000);
            Console.WriteLine(Screen.WaitUntilTheGameUpdate());
            Screen.ClearScreenAfterSeconds(3000);
            Console.WriteLine(Screen.GameUpdated());

            chosenOption = setup.SetupRetrieveOptionNameByKey(numberOption);

            foreach (var defeated in chosenOption.defeats)
            {
                Console.WriteLine(Screen.DefeatsOption(defeated.Value));
            }

            Screen.ClearScreenAfterSeconds(3000);
            MainMenu();
        }
    }
}

