using System.Collections.Generic;
using System;

namespace Generator.BNF {
    public class BNFParser : IBNFParser{
        public Dictionary<string, List<List<string>>> Parse(string bnfGrammarFile) {
            Dictionary<string, List<List<string>>> BNF = new Dictionary<string, List<List<string>>>();
            Queue<string> bnfFile = new Queue<string>(System.IO.File.ReadAllText(bnfGrammarFile).Split(new[]{' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries));
            string word, production = "ERROR";
            int expansionIndex = 0;
            while(bnfFile.Count > 0) {
                word = bnfFile.Dequeue();
                if(bnfFile.Count > 1 && bnfFile.Peek() == "->"){
                    production = word;
                    expansionIndex = 0;
                    BNF.Add(production, new List<List<string>>());
                    BNF[production].Add(new List<string>());
                    bnfFile.Dequeue();
                } else if(word == "|") {
                    expansionIndex++;
                    BNF[production].Add(new List<string>());
                } else
                    BNF[production][expansionIndex].Add(word);
            }
            return BNF;
        }
    }
}