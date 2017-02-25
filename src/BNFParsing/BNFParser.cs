using System;
using System.Collections.Generic;
using P4.Data;
using P4.BNFParsing;

namespace P4
{
    public class BNFParser
    {
        public static BNF Parse(string grammarFilePath = "Grammar.bnf")
        {
            List<Word> words = ParseFile(grammarFilePath);
            return ParseWords(words);
        }
        
        private static List<Word> ParseFile(string inputFilePath)
        {
        	// String is now filled with contents of file
        	string inputFileContent = System.IO.File.ReadAllText(inputFilePath);
        	
            // Split inputfile into lines, ignoring empty lines/whitespace
            string[] inputFileContentLines = inputFileContent.Split(new String[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            
            // Split lines into words, ignoring empty words and thereby whitespace
            string[][] inputFileContentWords = new string[inputFileContentLines.Length][];
            
            int line;
            int word;
            for(line = 0; line < inputFileContentLines.Length; line++)
            {
                inputFileContentWords[line] = inputFileContentLines[line].Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
            }
            Word detectedWord;
            List<Word> _bnf = new List<Word>();
            for (line = 0; line < inputFileContentWords.Length; line++)
            {
                for (word = 0; word < inputFileContentWords[line].Length; word++)
                {
                    detectedWord = new Word();
                    detectedWord.type = DetectWordType(line, word, inputFileContentWords);
                    detectedWord.word = inputFileContentWords[line][word];
                    if(detectedWord.type == Word.Type.Ignore)
                        break; // Don't read the rest of this line
                    _bnf.Add(detectedWord); // Add type to list
                    // Console.WriteLine("Line: {0}, Word: {1}: {2} Type {3}", line+1, word+1, inputFileContentWords[line][word], detectedWord.type);
                }
            }
            return _bnf;
        }

        private static Word.Type DetectWordType(int line, int word, String[][] inputFile) {
            if(word >= inputFile[line].Length) {
                word = 0;
                line++;
                if(line >= inputFile.Length)
                    return Word.Type.Ignore; // End of file
            }
            if(inputFile[line][word] == "EPSILON")
                return Word.Type.Epsilon;
            else if(DetectWordType(line, word+1, inputFile) == Word.Type.Equals)
                return Word.Type.NameSet;
            else if(inputFile[line][word] == "|")
                return Word.Type.Or;
            else if(inputFile[line][word] == "->")
                return Word.Type.Equals;
            else if(inputFile[line][word] == "//")
                return Word.Type.Ignore;
            else
                return Word.Type.NameRead;
        }

        private static BNF ParseWords(List<Word> BNF) {
            List<Production> productions = new List<Production>();
            List<Symbol> terminals = new List<Symbol>();
            // We run through all words to see which are Productions and which are not.
            foreach (Word word in BNF)
            {
                if(word.type == Word.Type.NameSet) {
                    Production production = new Production();
                    production.name = word.word;
                    production.expansions.Add(new Expansion());
                    productions.Add(production);
                }
            }
            Production currentProduction = productions[0];
            for(int wordIndex = 1; wordIndex < BNF.Count; wordIndex++) {
                switch(BNF[wordIndex].type) {
                    case Word.Type.NameSet:
                        // Find already defined production and use that.
                        Production production = productions.Find(x => x.name == BNF[wordIndex].word);
                        // Set production as currentProduction
                        currentProduction = production;
                    break;
                    case Word.Type.NameRead:
                    case Word.Type.Epsilon:
                        // See if production exists, use that
                        Symbol symbol = productions.Find(x => x.name == BNF[wordIndex].word);
                        // If no production
                        if(symbol == null)
                        {
                            symbol = terminals.Find(t => t.name == BNF[wordIndex].word);
                        }
                        // if no production or terminal create symbol
                        if(symbol == null) 
                        {
                            symbol = new Symbol();
                            symbol.name = BNF[wordIndex].word;
                            terminals.Add(symbol);
                        }
                        // Add to current productions last expansions list of symbols
                        currentProduction.expansions[currentProduction.expansions.Count-1].symbols.Add(symbol);
                    break;
                    case Word.Type.Or:
                        currentProduction.expansions.Add(new Expansion());
                        // Add new expansion
                    break;
                    case Word.Type.Equals:
                    case Word.Type.Ignore:
                        // Do nothing. These are not important now
                    break;
                    default:
                        // probably String, which isn't allowed
                        throw new ArgumentException("Switch case didn't recognize Word type");
                }
            }

            BNF bnf = new BNF(productions[0], productions, terminals);
            return bnf;
        }
    }
}