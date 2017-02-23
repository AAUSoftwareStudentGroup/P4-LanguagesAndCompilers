using System;
using System.Collections.Generic;

namespace P4.BNF.Parser
{
    class BNF_Parser
    {
        private List<Word> _bnf;
        public void Parse(string inputFilePath)
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
            _bnf = new List<Word>();
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
                    Console.WriteLine("Line: {0}, Word: {1}: {2} Type {3}", line+1, word+1, inputFileContentWords[line][word], detectedWord.type);
                }
            }
            bool syntaxIsValid = CheckBNFSyntax(_bnf);
            if(syntaxIsValid)
                Console.WriteLine("CheckBNFSyntax passed");
            else
                Console.WriteLine("Syntax did not pass");
        }
        public static Word.Type DetectWordType(int line, int word, String[][] inputFile) {
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
        public static bool CheckBNFSyntax(List<Word> BNF) {
            List<Production> productions = new List<Production>();
            token.Add(new Nonterminal(BNF[0].type, BNF[0].word)); // First type must be nonterminal, add it to the list
            Token currentNonterminal = token[0];
            Stack<Token> groupParent = new Stack<Token>(); // Stack, to enable nested groups

            // We run through all words to see which are nonterminals and which are not.
            List<Word> nonterminals = new List<Word>();
            foreach (Word word in BNF)
            {
                if(word.type == Word.Type.NameSet)
                    nonterminals.Add(word);
            }

            Token newToken = null;
            Token oldToken = null;
            for(int tokenIndex = 1; tokenIndex < BNF.Count; tokenIndex++) {
                switch(BNF[tokenIndex].type) {
                    case Word.Type.NameSet:
                        // See if symbol exists, change symbol to production
                        // If symbol doesnt exists, create new production
                        // Set production as currentProduction
                    break;
                    case Word.Type.NameRead:
                        // See if production exists, use that
                        // If no production, create symbol
                    break;
                    case Word.Type.Epsilon:
                        // Add production
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
            List<Token> ReachedNonterminals = new List<Token>();
            bool valid = token[0].syntaxIsValid(ReachedNonterminals);
            if(ReachedNonterminals.Count != nonterminals.Count) {
                Console.WriteLine("WARNING: Following non-terminals un-reachable from {0}:", token[0].word);
                foreach (Token t in ReachedNonterminals)
                {
                    nonterminals.Remove(nonterminals.Find(x => x.word == t.word));
                }
                foreach (Word word in nonterminals)
                {
                    Console.Write("{0}, ", word.word);
                }
                Console.WriteLine();
            }
            return valid;
        }
    }
}
