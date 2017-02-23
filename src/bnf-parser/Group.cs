using System.Collections.Generic;
using System;

namespace P4.BNF.Parser
{
    class Group : Token
    {
        override public string word {get; set;}
        override public Word.Type type {get; set;}
        override public List<Token> children {get; set;}
        public Group(Word word) {
            this.word = word.word;
            this.type = word.type;
            this.children = new List<Token>();
        }
        public Group(Token token) {
            this.word = token.word;
            this.type = token.type;
            this.children = token.children;
        }
        public Group(Word.Type type, string word) { // This has no children.
            this.word = word;
            this.type = type;
            this.children = new List<Token>();
        }
        public override bool syntaxIsValid(List<Token> symbols) {
            bool valid = true;
            foreach (Token child in children)
            {
                valid = valid && child.syntaxIsValid(symbols);
            }
            if(children.Count < 1)
                return false;
            return valid;
        }
    }
}