using System.Collections.Generic;

namespace Compiler.Parsing.BnfParsing
{
    public abstract class BnfToken
    {
        public abstract string Word {get; set;}
        public abstract WordType Type  {get; set;}
        public abstract List<BnfToken> Children {get ; set;}
        public abstract bool SyntaxIsValid(List<BnfToken> symbols);
    }
}