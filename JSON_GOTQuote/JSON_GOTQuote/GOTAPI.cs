using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_GOTQuote
{
    public class GOTAPI
    {
        public string quote;
        public string character;

        public override string ToString()
        {
            return $"'{quote}' -{character}";
        }
    }

   
}
