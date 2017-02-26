using System;

namespace Compiler.LexicalAnalysis.BnfParsing
{
    public class SyntaxErrorException : Exception 
    {
        public int Line { get; }
        public int Word { get; }
        public string WrongWord { get; }
        public SyntaxErrorException(int line, int word, string wrongWord) : base("Syntax error on line " + line + " word " + word + " at word: " + wrongWord)
        {
            Line = line;
            Word = word;
            WrongWord = wrongWord;
        }
    }
}