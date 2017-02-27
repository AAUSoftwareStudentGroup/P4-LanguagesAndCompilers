using System;
using System.Collections.Generic;
using Compiler.Data;

namespace Compiler.Parsing.BnfParsing
{
    public class BnfParser
    {
        public static Bnf Parse(string grammarFilePath = "Grammar.bnf")
        {
            List<Word> words = ParseFile(grammarFilePath);
            return ParseWords(words);
        }
        
        // Passes the raw file to words with wordtypes prior to parsing to a Bnf
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
                        // Find the type of word this is
                        Type = DetectWordType(line, word, inputFileContentWords),
                        Content = inputFileContentWords[line][word]
                    };
                    if (detectedWord.Type == Word.WordType.Ignore) // Comments
                        break; // Don't read the rest of this line
                    _bnf.Add(detectedWord); // Add type to list
                }
            }
            return _bnf;
        }

        // Detects a single word type and returns it
        private static Word.WordType DetectWordType(int line, int word, String[][] inputFile) {
            // If the word is past the end of the line, put pointer to first word on next line instead
            if(word >= inputFile[line].Length) {
                word = 0;
                line++;
                // If last word was the last in the file
                if(line >= inputFile.Length)
                    return Word.WordType.Ignore; // End of file
            }
            // Standard symbols are pretty straightforward
            if(inputFile[line][word] == "EPSILON")
                return Word.WordType.Epsilon;
            else if(inputFile[line][word] == "|")
                return Word.WordType.Or;
            else if(inputFile[line][word] == "->")
                return Word.WordType.Equals;
            else if(inputFile[line][word] == "//")
                return Word.WordType.Ignore;
            // Placed last to avoid unnessecary recursion
            // If the next word is an Equals, this must be a NameSet
            else if(DetectWordType(line, word+1, inputFile) == Word.WordType.Equals)
                return Word.WordType.NameSet;
            // If the next word isn't an Equals, this is a nameRead
            else
                return Word.WordType.NameRead;
        }

        // Parses the wordTypes and creates Bnf-"tree" from it
        private static Bnf ParseWords(List<Word> Words) {
            List<Production> productions = new List<Production>();
            List<Symbol> terminals = new List<Symbol>();
            // We run through all words to see which are Productions and which are not, to know all productions beforehand
            foreach (Word word in Words)
            {
                if(word.Type == Word.WordType.NameSet) { // A nameSet is a production
                    Production production = new Production()
                    {
                        Name = word.Content
                    };
                    // Create with the first expansion
                    production.Expansions.Add(new Expansion());
                    // Add to list of productions
                    productions.Add(production);
                }
            }
            // Add all tokens to this production, until next NameSet comes up
            Production currentProduction = productions[0];
            // For all words
            for(int wordIndex = 1; wordIndex < Words.Count; wordIndex++) {
                switch(Words[wordIndex].Type) {
                    // If word is a nameSet
                    case Word.WordType.NameSet: 
                        // This was found prior, so find production and use that.
                        Production production = productions.Find(x => x.Name == Words[wordIndex].Content);
                        // Set this production as currentProduction
                        currentProduction = production;
                    break;
                    case Word.WordType.NameRead:
                    case Word.WordType.Epsilon:
                        // See if production exists, use that
                        Symbol symbol = productions.Find(x => x.Name == Words[wordIndex].Content);
                        // If no production
                        if(symbol == null)
                        {
                            symbol = terminals.Find(t => t.Name == Words[wordIndex].Content);
                        }
                        // if no production or symbol, create symbol
                        if(symbol == null) 
                        {
                            symbol = new Symbol()
                            {
                                Name = Words[wordIndex].Content
                            };
                            // Add symbol to list of terminals/symbols
                            terminals.Add(symbol);
                        }
                        // Add to current productions last expansions list of symbols
                        currentProduction.Expansions[currentProduction.Expansions.Count-1].Symbols.Add(symbol);
                    break;
                    case Word.WordType.Or:
                        currentProduction.Expansions.Add(new Expansion());
                        // Add new expansion. Following terminals will be added to this
                    break;
                    case Word.WordType.Equals:
                    case Word.WordType.Ignore:
                        // Do nothing. These are not important now
                    break;
                    default:
                    // If something else comes up
                        throw new ArgumentException("ParseWords didn't recognize Word type");
                }
            }
            // Create Bnf with found data and return it
            Bnf bnf = new Bnf(productions[0], productions, terminals);
            return bnf;
        }
    }
}
