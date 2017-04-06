using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.BNF
{
    public interface IBNFAnalyzer
    {
        Dictionary<string, string[]> GetFollowSets(Dictionary<string, string[][]> bnf);
        Dictionary<string, string[]> GetFirstSets(Dictionary<string, string[][]> bnf);
        Dictionary<string, string[]> GetPredictSets(Dictionary<string, string[][]> bnf);
    }
}
