using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    class HauliException : Exception
    {
        private string _message;

        public HauliException(string m)
        {
            _message = m;
        }

        public override string Message
        { 
            get{ return _message; }
        }
    }
}
