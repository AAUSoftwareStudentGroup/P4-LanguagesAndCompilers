using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Grammar
{
    public interface IBNFAnalyzer
    {
        FollowSetTable GetFollowSets(BNF bnf, FirstSetTable firstSets);
        FirstSetTable GetFirstSets(BNF bnf);
        PredictSetTable GetPredictSets(BNF bnf, FirstSetTable firstSets, FollowSetTable followSets);
        bool IsLL1(BNF bnf, FirstSetTable firstSets, FollowSetTable followSets);
        GrammarInfo Analyze(BNF bnf);
    }
}
