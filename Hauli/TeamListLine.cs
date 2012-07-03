using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    public interface TeamListLine
    {
        int Id { get; set; }
        string Joukkue { get; set; }
    }


    public class Team : TeamListLine
    {
        private int id;
        private string joukkue;

        public Team(int id, string joukkue)
        {
            this.Id = id;
            this.Joukkue = joukkue;
        }

        public Team(Team c)
        {
            this.id = c.Id;
            this.joukkue = c.Joukkue;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Joukkue
        {
            get { return joukkue; }
            set { joukkue = value; }
        }
    }

    public class teamComparer : IEqualityComparer<TeamListLine>
    {
        public bool Equals(TeamListLine x, TeamListLine y)
        {
            return (x.Id == y.Id &&
                    x.Joukkue == y.Joukkue);
        }

        public int GetHashCode(TeamListLine obj)
        {
            return obj.Joukkue.GetHashCode() ^
                obj.Id;
        }
    }
}
