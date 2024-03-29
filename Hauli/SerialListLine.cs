﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    public interface SerialListLine
    {
        int Id { get; set; }
        string Sarja { get; set; }
    }


    public class Serial : SerialListLine
    {
        private int id;
        private string sarja;

        public Serial(int id, string sarja)
        {
            this.Id = id;
            this.Sarja = sarja;
        }

        public Serial(Serial c)
        {
            this.id = c.Id;
            this.sarja = c.Sarja;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Sarja
        {
            get { return sarja; }
            set { sarja = value; }
        }
    }

}
