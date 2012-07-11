using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    class RoundLine
    {
        private int round;
        private int subRound;
        private string text;

        public RoundLine(int round, int subRound) {
            this.round = round;
            this.subRound = subRound;
        }

        public int Round
        {
            get { return round; }
            set { round = value; }
        }

        public int SubRound
        {
            get { return subRound; }
            set { subRound = value; }
        }

        public string Text
        {
            get 
            {
                if (round > 0 && subRound > 0)
                    return "Erä " + round + "\nKierros " + subRound;
                else
                    return "";
            }
            set { text = value; }
        }
    }
}
