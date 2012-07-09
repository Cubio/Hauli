using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    class RoundLine
    {
        private int round;
        private string text;

        public RoundLine(int i, string s) {
            round = i;
            text = s;
        }

        public int Round
        {
            get { return round; }
            set { round = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}
