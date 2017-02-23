using System.Collections.Generic;
using System;

namespace bnf_parser
{
    class Or : Token
    {
        override public string word {get; set;}
        override public Word.Type type{get; set;}
        override public List<Token> children{get; set;}

        public Or(Word word) {
            this.word = word.word;
            this.type = word.type;
            this.children = new List<Token>();
        }
        public Or(Token token) {
            this.word = token.word;
            this.type = token.type;
            this.children = token.children;
        }
        public Or(Word.Type type, string word) {
            this.word = word;
            this.type = type;
        }
        public override bool syntaxIsValid(List<Token> symbols) {
            bool valid = true;
            foreach (Token child in children)
            {
                valid = valid && child.syntaxIsValid(symbols);
            }
            if(children.Count < 2)
                return false;
            return valid;
        }
    }
}