using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    public interface ContestantListLine
    {
        //public ContestantListLine() { }

        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }
        string Seura { get; set; }
        string Sarja { get; set; }
        string Team { get; set; }
    }


    public class Contestant : ContestantListLine
    {
        private string id;
        private string firstName;
        private string lastName;
        private string fullName;
        private string seura;
        private string sarja;
        private string team;

        public Contestant(string id, string firstName, string lastName, string seura, string sarja, string team)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Seura = seura;
            this.Sarja = sarja;
            this.Team = team;
        }

        public Contestant(Contestant c)
        {
            this.id = c.Id;
            this.FirstName = c.FirstName;
            this.LastName = c.LastName;
            this.Seura = c.Seura;
            this.Sarja = c.Sarja;
            this.Team = c.Team;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FullName
        {
            get 
            {
                fullName = firstName + " " + lastName;
                return fullName;   
            }
            set { fullName = value; }
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


    public class RoundDivider : ContestantListLine
    {
        private string id;
        private string name = "";
        private string seura = "";
        private string sarja = "";
        private string team = "";

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return null; }
            set {}
        }

        public string LastName
        {
            get { return null; }
            set {}
        }

        public string FullName
        {
            get { return name; }
            set { name = value; }
        }
        public string Seura { get; set; }
        public string Sarja { get; set; }
        public string Team { get; set; }

        public RoundDivider(string id, string round)
        {
            this.Id = id;
            this.FullName = round;
        }
    }

}
