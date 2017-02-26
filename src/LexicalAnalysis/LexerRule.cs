using System;
using System.Text.RegularExpressions;

namespace Compiler.LexicalAnalasis {
    public class LexerRule
    {
        public String Name { get; set; }
        public Regex Pattern { get; set; }
        public String PatternString { get; set; }
        public bool SingleLine { get; set; } = false;
        public bool Ignore { get; set; } = false;
    }
}