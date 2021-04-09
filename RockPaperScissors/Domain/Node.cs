using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Domain
{
    public sealed class Options
    {
        public string value { get; set; }
        public int key { get; set; }
        public Options next { get; internal set; }
        public Dictionary<int, string> defeats { get; set; }

        public Options(string v, int k)
        {
            value = v;
            key = k;
            defeats = new Dictionary<int, string>();
        }
    }
}

