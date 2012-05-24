using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    /// <summary>
    /// Heitettävä Exception-luokka, sisältää virheviestin.
    /// </summary>
    class HauliException : Exception
    {
        private string _message;

        /// <summary>
        /// Tallentaa parametrin virheviestin.
        /// </summary>
        public HauliException(string m)
        {
            _message = m;
        }

        /// <summary>
        /// Palauttaa HauliExceptionin sisältämän virheviestin.
        /// </summary>
        public override string Message
        { 
            get{ return _message; }
        }
    }
}
