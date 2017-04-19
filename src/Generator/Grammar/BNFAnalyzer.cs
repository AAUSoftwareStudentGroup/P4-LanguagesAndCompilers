using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Generator.Grammar
{
    public class BNFAnalyzer : IBNFAnalyzer
    {
        string _emptySymbol;

        public BNFAnalyzer(string emptySymbol)
        {
            _emptySymbol = emptySymbol;
        }

        public BNFAnalyzer() : this("EPSILON")
        { }

        bool IsTerminal(string symbol, BNF bnf)
        {
            return !bnf.ContainsKey(symbol);
        }

        bool IsNonTerminal(string symbol, BNF bnf)
        {
            return !IsTerminal(symbol, bnf);
        }

        public FirstSetTable GetFirstSets(BNF bnf)
        {
            FirstSetTable sets = new FirstSetTable();
            foreach (var production in bnf)
            {
                GetSymbolFirstSet(production.Key, bnf, sets);
            }
            return sets;
        }

        HashSet<string> GetSymbolFirstSet(string symbol, BNF bnf, FirstSetTable firstSets)
        {
            if(firstSets.SymbolSets.ContainsKey(symbol))
            {
                return firstSets.SymbolSets[symbol];
            }
            else
            {
                if(IsTerminal(symbol, bnf))
                {
                    HashSet<string> set = new HashSet<string>() { symbol };
                    firstSets.SymbolSets.Add(symbol, set);
                    return set;
                }
                else
                {
                    HashSet<string> set = new HashSet<string>();
                    var expansions = bnf[symbol];
                    for (int index = 0; index < expansions.Count; index++)
                    {
                        var expansionSet = GetExpansionFirstSet(symbol, index, bnf, firstSets);
                        if (expansions[index].Count == 1 && expansions[index][0] == _emptySymbol)
                        {
                            set.Add(_emptySymbol);
                        }
                        else
                        {
                            set.UnionWith(expansionSet);
                        }
                    }
                    firstSets.SymbolSets.Add(symbol, set);
                    return set;
                }
            }
        }

        HashSet<string> GetExpansionFirstSet(string production, int expansionIndex, BNF bnf, FirstSetTable firstSets)
        {
            if(firstSets.ExpansionSets.ContainsKey((production, expansionIndex)))
            {
                return firstSets.ExpansionSets[(production, expansionIndex)];
            }
            else
            {
                HashSet<string> expansionSet = GetSymbolFirstSet(bnf[production][expansionIndex][0], bnf, firstSets);
                if (!expansionSet.Contains(_emptySymbol))
                {
                    firstSets.ExpansionSets.Add((production, expansionIndex), expansionSet);
                    return expansionSet;
                }
                else
                {
                    expansionSet = GetSymbolsFirstSet(bnf[production][expansionIndex], bnf, firstSets);

                    firstSets.ExpansionSets.Add((production, expansionIndex), expansionSet);

                    return expansionSet;
                }
            }
        }

        public HashSet<string> GetSymbolsFirstSet(List<string> symbols, BNF bnf, FirstSetTable firstSets)
        {
            var expansionSet = new HashSet<string>();

            bool allEpsilon = true;

            foreach (var symbol in symbols)
            {
                var symbolFirstSet = GetSymbolFirstSet(symbol, bnf, firstSets);

                if (symbolFirstSet.Contains(_emptySymbol))
                {
                    expansionSet.UnionWith(new HashSet<string>(symbolFirstSet.Where(s => s != _emptySymbol)));
                }
                else
                {
                    expansionSet.UnionWith(symbolFirstSet);
                    allEpsilon = false;
                    break;
                }
            }

            if (allEpsilon)
            {
                expansionSet.Add(_emptySymbol);
            }

            return expansionSet;
        }

        public FollowSetTable GetFollowSets(BNF bnf, FirstSetTable firstSets)
        {
            FollowSetTable followSets = new FollowSetTable();

            foreach (var production in bnf)
            {
                followSets.Add(production.Key, new HashSet<string>());
            }

            while (IterateFollow(bnf, followSets, firstSets) == true) ;

            return followSets;
        }

        bool IterateFollow(BNF bnf, FollowSetTable followSets, FirstSetTable firstSets)
        {
            bool changed = false;

            foreach (var nonterminal in bnf.Keys)
            {
                int p = 0;
                foreach (var production in bnf)
                {
                    int e = 0;
                    foreach (var expansion in production.Value)
                    {
                        int s = 0;
                        foreach (var symbol in expansion)
                        {
                            if(nonterminal == symbol)
                            {
                                int oldCount = followSets[nonterminal].Count();
                                var tailFirstSet = GetSymbolsFirstSet(expansion.Skip(s + 1).ToList(), bnf, firstSets);
                                bool derivesEmpty = tailFirstSet.Contains("EPSILON") || s == expansion.Count - 1;
                                followSets[nonterminal] = followSets[nonterminal].Union(new HashSet<string>(tailFirstSet.Where(sy => sy != "EPSILON")));
                                if(derivesEmpty)
                                {
                                    followSets[nonterminal] = followSets[nonterminal].Union(new HashSet<string>(followSets[production.Key]));
                                }
                                if(oldCount != followSets[nonterminal].Count())
                                {
                                    changed = true;
                                }
                            }
                            s++;
                        }
                        e++;
                    }
                    p++;
                }
            }
            

            return changed;
        }

        public PredictSetTable GetPredictSets(BNF bnf, FirstSetTable firstSets, FollowSetTable followSets)
        {
            PredictSetTable predictSets = new PredictSetTable();

            foreach (var production in bnf)
            {
                for (int expansionIndex = 0; expansionIndex < production.Value.Count; expansionIndex++)
                {
                    HashSet<string> predictSet = new HashSet<string>(firstSets.ExpansionSets[(production.Key, expansionIndex)]);
                    if(predictSet.Contains(_emptySymbol))
                    {
                        predictSet.RemoveWhere(s => s == _emptySymbol);
                        predictSet.UnionWith(followSets[production.Key]);
                    }
                    predictSets.Add((production.Key, expansionIndex), predictSet);
                }
            }

            return predictSets;
        }

        // If condition 1 and 2 is true then the bnf is ll1
        public bool IsLL1(BNF bnf, FirstSetTable firstSets, FollowSetTable followSets)
        {
            return Ll1Condition1(bnf, firstSets) && Ll1Condition2(bnf, firstSets, followSets);
        }

        // Checks if the Firstset of a production only contains distincs elements 
        public bool Ll1Condition1(BNF bnf, FirstSetTable firstSets)
        {
            foreach (var production in bnf)
            {
                HashSet<string> union = new HashSet<string>();
                for (int expansionIndex = 0; expansionIndex < production.Value.Count; expansionIndex++)
                {
                    var expansionFirstSet = firstSets.ExpansionSets[(production.Key, expansionIndex)];
                    if (union.Intersect(expansionFirstSet).Count() > 0)
                    {
                        return false;
                    }
                    union.UnionWith(expansionFirstSet);
                }
            }
            return true;
        }

        // Checks if the set of first and followset of a production only contains distinct elements
        public bool Ll1Condition2(BNF bnf, FirstSetTable firstSets, FollowSetTable followSets)
        {
            foreach (var production in bnf)
            {
                var firstSet = firstSets.SymbolSets[production.Key];
                var followSet = followSets[production.Key];
                if (firstSet.Contains("EPSILON") && firstSet.Intersect(followSet).Count() > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public GrammarInfo Analyze(BNF bnf)
        {
            FirstSetTable firstSets = GetFirstSets(bnf);
            FollowSetTable followSets = GetFollowSets(bnf, firstSets);
            PredictSetTable predictSets = GetPredictSets(bnf, firstSets, followSets);
            bool isLL1 = IsLL1(bnf, firstSets, followSets);

            return new GrammarInfo()
            {
                IsLL1 = isLL1,
                FirstSets = firstSets,
                FollowSets = followSets,
                PredictsSets = predictSets
            };
        }
    }
}
