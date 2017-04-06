using System.Collections.Generic;

namespace Generator.Grammar {
    public interface IBNFParser{
        Dictionary<string, List<List<string>>> Parse(string bnfGrammarFile);
    }
}