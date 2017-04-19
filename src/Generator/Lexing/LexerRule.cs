using System;
using System.Text.RegularExpressions;

namespace Generator.Lexing
{
    public class LexerRule
    {
        public String Name;
        public Regex Pattern;
        public String PatternString;
        public bool SingleLine = false;
        public bool Ignore = false;
    }
}