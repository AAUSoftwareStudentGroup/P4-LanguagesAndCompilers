using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Generator.BNF
{
    public class BNFAnalyzer : IBNFAnalyzer
    {
        private bool IsTerminal(string symbol, Dictionary<string, string[][]> bnf)
        {
            return !bnf.Keys.Any((nonTerminal) => nonTerminal == symbol);
        }

        private bool IsNonTerminal(string symbol, Dictionary<string, string[][]> bnf)
        {
            return !IsTerminal(symbol, bnf);
        }

        public Dictionary<string, string[]> GetFirstSets(Dictionary<string, string[][]> bnf)
        {
            Dictionary<string, List<string>> firstSets = new Dictionary<string, List<string>>();

            firstSets = new Dictionary<string, List<string>>();

            foreach (var production in bnf)
            {
                firstSets[production.Key] = new List<string>();
                int expensionIndex = 0;

                foreach (var expansion in production.Value)
                {
                    firstSets[$"{production.Key}${expensionIndex}"] = new List<string>();

                    foreach (var symbol in expansion)
                    {
                        firstSets[symbol] = new List<string>();

                        if (IsTerminal(symbol, bnf))
                        {
                            firstSets[symbol] = new List<string>() { symbol };
                        }
                        if(expansion.Length == 1 && symbol == "EPSILON")
                        {
                        }
                    }
                }
            }
            return null;
        }

        public Dictionary<string, string[]> GetFollowSets(Dictionary<string, string[][]> bnf)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string[]> GetPredictSets(Dictionary<string, string[][]> bnf)
        {
            throw new NotImplementedException();
        }
    }
}
