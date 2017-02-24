using System;

namespace P4.BNFParsing
{
    public class SyntaxErrorException : Exception 
    {
        public int line;
        public int word;
        public string wrongWord;
        public SyntaxErrorException(int line, int word, string wrongWord) : base("Syntax error on line " + line + " word " + word + " at word: " + wrongWord)
        {
            this.line = line;
            this.word = word;
            this.wrongWord = wrongWord;
        }
    }
}