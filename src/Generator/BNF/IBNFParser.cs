using System.Collections.Generic;

namespace Generator.BNF {
    public interface IBNFParser{
        Dictionary<string, List<List<string>>> Parse(string bnfGrammarFile);
    }
}