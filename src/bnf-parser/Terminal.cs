using System.Collections.Generic;

namespace bnf_parser
{
    class Terminal : Token
    {
        override public string word {get; set;}
        override public Word.Type type {get; set;}
        override public List<Token> children {get; set;}
        public Terminal(Word word) {
            this.word = word.word;
            this.type = word.type;
        }
        public Terminal(Token token) {
            this.word = token.word;
            this.type = token.type;
            this.children = token.children;
        }
        public Terminal(Word.Type type, string word) { // This has no children.
            this.word = word;
            this.type = type;
        }
         public override bool syntaxIsValid(List<Token> symbols) {
            symbols.Add(this);
            return true;
        }
    }
}