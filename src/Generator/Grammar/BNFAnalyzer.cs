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
                    string[][] expansions = bnf[symbol];
                    for (int index = 0; index < expansions.Length; index++)
                    {
                        var expansionSet = GetExpansionFirstSet(symbol, index, bnf, firstSets);
                        if (expansions[index].Length == 1 && expansions[index][0] == _emptySymbol)
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

        public HashSet<string> GetSymbolsFirstSet(string[] symbols, BNF bnf, FirstSetTable firstSets)
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
                GetProductionFollowSet(production.Key, bnf, followSets, firstSets);
            }
            return followSets;
        }

        HashSet<string> GetProductionFollowSet(string symbol, BNF bnf, FollowSetTable followSets, FirstSetTable firstSets)
        {
            if (followSets.ContainsKey(symbol))
            {
                return followSets[symbol];
            }

            HashSet<string> followSet = new HashSet<string>();

            foreach (var production in bnf)
            {
                foreach (var expansion in production.Value)
                {
                    for (int i = 0; i < expansion.Length; i++)
                    {
                        string expansionSymbol = expansion[i];
                        if (expansionSymbol == symbol)
                        {
                            if (i < expansion.Length - 1)
                            {
                                var tailFirstSet = new HashSet<string>(GetSymbolsFirstSet(expansion.Skip(i + 1).ToArray(), bnf, firstSets));

                                bool tailFirstSetContainsEpsilon = false;

                                foreach (var s in tailFirstSet)
                                {
                                    if (s == _emptySymbol)
                                    {
                                        tailFirstSetContainsEpsilon = true;
                                        break;
                                    }
                                }

                                tailFirstSet.RemoveWhere(s => s == _emptySymbol);

                                followSet.UnionWith(tailFirstSet);
                                if (tailFirstSetContainsEpsilon)
                                {
                                    followSet.UnionWith(GetProductionFollowSet(production.Key, bnf, followSets, firstSets));
                                }
                            }
                            else
                            {
                                followSet.UnionWith(GetProductionFollowSet(production.Key, bnf, followSets, firstSets));
                            }
                        }
                    }
                }
            }

            followSets.Add(symbol, followSet);

            return followSet;
        }

        public PredictSetTable GetPredictSets(BNF bnf, FirstSetTable firstSets, FollowSetTable followSets)
        {
            PredictSetTable predictSets = new PredictSetTable();

            foreach (var production in bnf)
            {
                for (int expansionIndex = 0; expansionIndex < production.Value.Length; expansionIndex++)
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
                for (int expansionIndex = 0; expansionIndex < production.Value.Length; expansionIndex++)
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
