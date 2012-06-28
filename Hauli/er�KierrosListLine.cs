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
        string Erä { get; set; }
        string Kierros { get; set; }
    }

    class eräKierrosListLine
    {
    }
}
