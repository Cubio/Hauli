using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    public interface SeuraListLine 
    {
        int Id { get; set; }
        string Lyhenne { get; set; }
        string KokoNimi { get; set; }
        string Alue { get; set; }
    }


    public class Seura : SeuraListLine
    {
        private int id;
        private string lyhenne;
        private string kokoNimi;
        private string alue;

        public Seura(int id, string lyhenne, string kokoNimi, string alue)
        {
            this.Id = id;
            this.Lyhenne = lyhenne;
            this.KokoNimi = kokoNimi;
            this.Alue = alue;
        }

        public Seura(Seura c)
        {
            this.id = c.Id;
            this.lyhenne = c.Lyhenne;
            this.kokoNimi = c.KokoNimi;
            this.alue = c.Alue;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Lyhenne
        {
            get { return lyhenne; }
            set { lyhenne = value; }
        }

        public string KokoNimi
        {
            get { return kokoNimi; }
            set { kokoNimi = value; }
        }

        public string Alue
        {
            get { return alue; }
            set { alue = value; }
        }

    }

    public class seuraComparer : IEqualityComparer<SeuraListLine>
    {
            public bool Equals(SeuraListLine x, SeuraListLine y)
            {
                return (x.Alue == y.Alue &&
                        x.KokoNimi == y.KokoNimi &&
                        x.Lyhenne == y.Lyhenne &&
                        x.Id == y.Id);
            }
 
            public int GetHashCode(SeuraListLine obj)
            {
                return obj.Alue.GetHashCode() ^
                    obj.Id ^
                    obj.Lyhenne.GetHashCode() ^
                    obj.KokoNimi.GetHashCode();
            }
    }

}
