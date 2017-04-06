using System.Collections.Generic;

namespace Generator.BNF {
    public interface IBNFParser {
        Dictionary<string, string[][]> ParseBNF(string bnfGrammarFile);
    }
}