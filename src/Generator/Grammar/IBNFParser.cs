using System.Collections.Generic;

namespace Generator.Grammar {
    public interface IBNFParser{
        BNF Parse(string bnfGrammarFile);
    }
}