using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Core
{
    public static class Util
    {
        public static bool KeyIsDigit(char keyChar)
        {
            return char.IsDigit(keyChar);
        }

        public static int KeyCharToInt(char keyChar)
        {
            return Convert.ToInt32(keyChar.ToString());
        }
    }
}
