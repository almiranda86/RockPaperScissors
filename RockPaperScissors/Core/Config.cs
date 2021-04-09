using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Core
{
    public static class Config
    {
        public static string ROCK = nameof(ROCK);
        public static string PAPER = nameof(PAPER);
        public static string SCISSOR = nameof(SCISSOR);

        public static string[] OPTIONS = {ROCK, PAPER, SCISSOR };
    }
}
