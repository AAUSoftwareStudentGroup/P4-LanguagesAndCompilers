using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Lexing
{
    public class Token
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
