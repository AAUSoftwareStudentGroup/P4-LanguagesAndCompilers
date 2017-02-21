using System;
using System.Text.RegularExpressions;

namespace P4.Lexer {
    public class TokenRule
    {
        public String Name;
        public Regex Pattern;
        public String PatternString;
        public bool SingleLine = false;
        public bool Ignore = false;
    }
}