using System.Collections.Generic;

namespace P4.BNF.Parser
{
    abstract class Token
    {
        public abstract string word {get; set;}
        public abstract Word.Type type  {get; set;}
        public abstract List<Token> children {get ; set;}
        public abstract bool syntaxIsValid(List<Token> symbols);
    }
}