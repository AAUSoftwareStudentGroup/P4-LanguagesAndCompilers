using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.LexicalAnalysis
{
    public class Token
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
