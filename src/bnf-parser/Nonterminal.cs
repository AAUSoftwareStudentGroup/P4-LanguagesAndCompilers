using System.Collections.Generic;
using System;

namespace P4.BNF.Parser
{
    class Nonterminal : Token
    {
        override public string word {get; set;}
        override public Word.Type type {get; set;}
        override public List<Token> children {get; set;}
        public Nonterminal(Word word) {
            this.word = word.word;
            this.type = word.type;
            this.children = new List<Token>();
        }
        public Nonterminal(Token token) {
            this.word = token.word;
            this.type = token.type;
            if(token.children != null)
                this.children = token.children;
            else
                this.children = new List<Token>();
        }
        public Nonterminal(Word.Type type, string word) { // This has no children.
            this.word = word;
            this.type = type;
            this.children = new List<Token>();
        }
        public override bool syntaxIsValid(List<Token> symbols) {
            bool valid = true;
            if(symbols.Contains(this))
                return true;
            symbols.Add(this);
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


