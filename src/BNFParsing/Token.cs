using System.Collections.Generic;

namespace P4.BNFParsing
{
    public abstract class BNFToken
    {
        public abstract string word {get; set;}
        public abstract Word.Type type  {get; set;}
        public abstract List<BNFToken> children {get ; set;}
        public abstract bool syntaxIsValid(List<BNFToken> symbols);
    }
}