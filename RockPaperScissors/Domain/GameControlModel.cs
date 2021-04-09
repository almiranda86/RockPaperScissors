using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Domain
{
    public class GameControlModel
    {
        public Dictionary<string, int> Score { get; set; }

        public string Player1Option { get; set; }

        public string Player2Option { get; set; }

        public int RoundResult { get; set; }

        public GameControlModel()
        {
            Score = new Dictionary<string, int>();
        }
    }
}
