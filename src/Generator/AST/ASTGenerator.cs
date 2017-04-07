using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using Generator.Grammar;

namespace Generator.AST
{
    public class ASTGenerator : IASTGenerator
    {
        public void Generate(string formationRulesFile, string targetDirectory, string targetNamespace) 
        {
            Generate((new BNFParser()).Parse(formationRulesFile), targetDirectory, targetNamespace);
        }
        public void Generate(Dictionary<string, List<List<string>>> bnf, string targetDirectory, string targetNamespace) 
        {
            ReplaceTokensAndNames("SemanticTokensAndNames.bnf", bnf);
            // Must be named according to NamesAndTokens
            // Convert each production into a class
            // Each class must know what 'children' it has and if it has parents
        }
        public Dictionary<string, List<List<string>>> ReplaceTokensAndNames(string tokenAndNamesFile, Dictionary<string, List<List<string>>> bnf) {
            Dictionary<string, string> tokens = ParseTokensFromFile(tokenAndNamesFile);
            Dictionary<string, List<List<string>>> FixedBnf = new Dictionary<string, List<List<string>>>();

            foreach(KeyValuePair<string, List<List<string>>> rule in bnf) 
            {
                KeyValuePair<string, List<List<string>>> newRule = new KeyValuePair<string, List<List<string>>>(rule.Key.ToString(), new List<List<string>>());
                foreach(List<string> expansion in rule.Value) 
                {
                    List<string> newExpansion = new List<string>();
                    foreach(string symbol in expansion) 
                    {
                        string newSymbol = symbol; 
                        foreach(KeyValuePair<string, string> token in tokens) 
                        {
                            // Replace token.key in symbol with token.value
                            newSymbol = newSymbol.Replace(token.Key, token.Value); // This might fuck up hard
                        }
                        newExpansion.Add(newSymbol);
                    }
                    newRule.Value.Add(newExpansion);
                }
                string NewKey = newRule.Key;
                foreach(KeyValuePair<string, string> token in tokens) 
                {
                    // Replace token.key in symbol with token.value
                    NewKey = NewKey.Replace(token.Key, token.Value); // This might fuck up hard
                }
                FixedBnf.Add(NewKey, newRule.Value);
            }
            return FixedBnf;
        }
        public Dictionary<string, string> ParseTokensFromFile(string filePath) {
            return ParseTokens(System.IO.File.ReadAllText(filePath));
        }
        public Dictionary<string, string> ParseTokens(string rawTokens) {
            Dictionary<string, string> tokensProcessed = new Dictionary<string, string>();
            Queue<string> tokens = new Queue<string>(rawTokens.Split(new[]{' ', '\n'}, StringSplitOptions.RemoveEmptyEntries));
            int i;
            while(tokens.Count > 0) {
                string word = tokens.Dequeue();
                tokens.Dequeue(); // '='
                string definition = tokens.Dequeue();
                while((i = definition.IndexOf('#')) >= 0) {
                    definition = definition.Insert(i+2, tokensProcessed[definition[i+1].ToString()]);
                    definition = definition.Remove(i, 2);
                }
                tokensProcessed.Add(word, definition);
            }
            return tokensProcessed;
        }
    }
}
