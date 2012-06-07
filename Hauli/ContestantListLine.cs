using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    public interface ContestantListLine
    {
        //public ContestantListLine() { }

        string ContestantNumber { get; set; }
        string Name { get; set; }
        string Seura { get; set; }
        string Sarja { get; set; }
        string Team { get; set; }
    }


    class Contestant : ContestantListLine
    {
        private string contestantNumber;
        private string name;
        private string seura;
        private string sarja;
        private string team;

        public Contestant(string contestantNumber, string name, string seura, string sarja, string team)
        {
            this.ContestantNumber = contestantNumber;
            this.Name = name;
            this.Seura = seura;
            this.Sarja = sarja;
            this.Team = team;
        }

        public string ContestantNumber
        {
            get { return contestantNumber; }
            set { contestantNumber = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Seura
        {
            get { return seura; }
            set { seura = value; }
        }

        public string Sarja
        {
            get { return sarja; }
            set { sarja = value; }
        }

        public string Team
        {
            get { return team; }
            set { team = value; }
        }

    }


    class RoundDivider : ContestantListLine
    {
        private string contestantNumber;
        private string name = "";
        private string seura = "";
        private string sarja = "";
        private string team = "";

        public string ContestantNumber { get; set; }
        public string Name
        {
            get { return name; }
            set {}
        }
        public string Seura { get; set; }
        public string Sarja { get; set; }
        public string Team { get; set; }

        public RoundDivider(string round)
        {
            name = round;
        }
    }

}
