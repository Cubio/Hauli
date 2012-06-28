using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    public interface eräKierrosListLine
    {
        string Id { get; set; }
        string Klo { get; set; }
        string EräKierros1 { get; set; }
        string EräKierros2 { get; set; }
        string EräKierros3 { get; set; }
        string EräKierros4 { get; set; }
        string EräKierros5 { get; set; }
        string EräKierros6 { get; set; }
    }

    public class Erä : eräKierrosListLine
    {
        private string id;
        private string klo;
        private string eräKierros1;
        private string eräKierros2;
        private string eräKierros3;
        private string eräKierros4;
        private string eräKierros5;
        private string eräKierros6;


        public Erä(/*string id,*/ string klo, string eräKierros1, string eräKierros2, string eräKierros3, string eräKierros4, string eräKierros5, string eräKierros6)
        {
           // this.Id = id;
            this.Klo = klo;
            this.EräKierros1 = eräKierros1;
            this.EräKierros2 = eräKierros2;
            this.EräKierros3 = eräKierros3;
            this.EräKierros4 = eräKierros4;
            this.EräKierros5 = eräKierros5;
            this.EräKierros6 = eräKierros6;
        }

        public Erä(Erä c)
        {
            this.id = c.Id;
            this.klo = c.Klo;
            this.EräKierros1 = c.EräKierros1;
            this.EräKierros2 = c.EräKierros2;
            this.EräKierros3 = c.EräKierros3;
            this.EräKierros4 = c.EräKierros4;
            this.EräKierros5 = c.EräKierros5;
            this.EräKierros6 = c.EräKierros6;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Klo
        {
            get { return klo; }
            set { klo = value; }
        }

        public string EräKierros1
        {
            get { return eräKierros1; }
            set { eräKierros1 = value; }
        }

        public string EräKierros2
        {
            get { return eräKierros2; }
            set { eräKierros2 = value; }
        }

        public string EräKierros3
        {
            get { return eräKierros3; }
            set { eräKierros3 = value; }
        }

        public string EräKierros4
        {
            get { return eräKierros4; }
            set { eräKierros4 = value; }
        }

        public string EräKierros5
        {
            get { return eräKierros5; }
            set { eräKierros5 = value; }
        }

        public string EräKierros6
        {
            get { return eräKierros6; }
            set { eräKierros6 = value; }
        }
    }
    /*class eräKierrosListLine
    {
    }*/
}
