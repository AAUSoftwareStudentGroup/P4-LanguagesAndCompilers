using System;
using System.Collections.Generic;
using Compiler.Data;
using Compiler.Parsing.BnfParsing;

namespace Compiler
{
    public class BnfParser
    {
        public static Bnf Parse(string grammarFilePath = "Grammar.bnf")
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
                    detectedWord = new Word()
                    {
                        Type = DetectWordType(line, word, inputFileContentWords),
                        Content = inputFileContentWords[line][word]
                    };
                    if (detectedWord.Type == WordType.Ignore)
                        break; // Don't read the rest of this line
                    _bnf.Add(detectedWord); // Add type to list
                    // Console.WriteLine("Line: {0}, Word: {1}: {2} Type {3}", line+1, word+1, inputFileContentWords[line][word], detectedWordType);
                }
            }
            return _bnf;
        }

        private static WordType DetectWordType(int line, int word, String[][] inputFile) {
            if(word >= inputFile[line].Length) {
                word = 0;
                line++;
                if(line >= inputFile.Length)
                    return WordType.Ignore; // End of file
            }
            if(inputFile[line][word] == "EPSILON")
                return WordType.Epsilon;
            else if(DetectWordType(line, word+1, inputFile) == WordType.Equals)
                return WordType.NameSet;
            else if(inputFile[line][word] == "|")
                return WordType.Or;
            else if(inputFile[line][word] == "->")
                return WordType.Equals;
            else if(inputFile[line][word] == "//")
                return WordType.Ignore;
            else
                return WordType.NameRead;
        }

        private static Bnf ParseWords(List<Word> BNF) {
            List<Production> productions = new List<Production>();
            List<Symbol> terminals = new List<Symbol>();
            // We run through all words to see which are Productions and which are not.
            foreach (Word word in BNF)
            {
                if(word.Type == WordType.NameSet) {
                    Production production = new Production()
                    {
                        Name = word.Content
                    };
                    production.Expansions.Add(new Expansion());
                    productions.Add(production);
                }
            }
            Production currentProduction = productions[0];
            for(int wordIndex = 1; wordIndex < BNF.Count; wordIndex++) {
                switch(BNF[wordIndex].Type) {
                    case WordType.NameSet:
                        // Find already defined production and use that.
                        Production production = productions.Find(x => x.Name == BNF[wordIndex].Content);
                        // Set production as currentProduction
                        currentProduction = production;
                    break;
                    case WordType.NameRead:
                    case WordType.Epsilon:
                        // See if production exists, use that
                        Symbol symbol = productions.Find(x => x.Name == BNF[wordIndex].Content);
                        // If no production
                        if(symbol == null)
                        {
                            symbol = terminals.Find(t => t.Name == BNF[wordIndex].Content);
                        }
                        // if no production or terminal create symbol
                        if(symbol == null) 
                        {
                            symbol = new Symbol()
                            {
                                Name = BNF[wordIndex].Content
                            };
                            terminals.Add(symbol);
                        }
                        // Add to current productions last expansions list of symbols
                        currentProduction.Expansions[currentProduction.Expansions.Count-1].Symbols.Add(symbol);
                    break;
                    case WordType.Or:
                        currentProduction.Expansions.Add(new Expansion());
                        // Add new expansion
                    break;
                    case WordType.Equals:
                    case WordType.Ignore:
                        // Do nothing. These are not important now
                    break;
                    default:
                        // probably String, which isn't allowed
                        throw new ArgumentException("Switch case didn't recognize Word type");
                }
            }

            Bnf bnf = new Bnf(productions[0], productions, terminals);
            return bnf;
        }
    }
}
