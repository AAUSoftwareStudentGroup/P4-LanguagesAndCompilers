using System.Collections.Generic;
using System;

namespace Generator.Grammar {
    public class BNFParser : IBNFParser{
        public BNF Parse(string bnfGrammarFile) {
            BNF BNF = new BNF();
            Queue<string> bnfFile = new Queue<string>(System.IO.File.ReadAllText(bnfGrammarFile).Split(new[]{' ', '\n', '\t', '\r'}, StringSplitOptions.RemoveEmptyEntries));
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
                } else if(word[0] == '\\') {
                    BNF[production][expansionIndex].Add(word.Substring(1));
                } else 
                    BNF[production][expansionIndex].Add(word);
            }
            return BNF;
        }
    }
}