using System;

namespace bnf_parser
{
    class BNF_Parser
    {
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
            
            for (line = 0; line < inputFileContentWords.Length; line++)
            {
                for (word = 0; word < inputFileContentWords[line].Length; word++)
                {
                    Word.Type type = DetectWordType(line, word, inputFileContentWords);
                    Console.WriteLine("Line: {0}, Word: {1}: {2} Type {3}", line+1, word+1, inputFileContentWords[line][word], type);
                }
            }
        }
        public static Word.Type DetectWordType(int line, int word, String[][] inputFile) {
            // Check if this is the first word on a line and the last word on the last line wasn't \
            if(word == 0 && (line == 0 || inputFile[line-1][inputFile[line-1].Length-1] != @"\"))
                return Word.Type.NameSet;
            else if(inputFile[line][word].StartsWith(@"<")) // This is a name we expect to read
                return Word.Type.NameRead;
            else if(inputFile[line][word].StartsWith("\"") || inputFile[line][word].StartsWith("'")) // This is a constant string
                return Word.Type.String;
            else if(inputFile[line][word] == "|")
                return Word.Type.Or;
            else if(inputFile[line][word] == "(")
                return Word.Type.GroupStart;
            else if(inputFile[line][word] == ")")
                return Word.Type.GroupEnd;
            else if(inputFile[line][word] == "::=")
                return Word.Type.Equals;
            else
                throw new SyntaxErrorException(line+1, word+1, inputFile[line][word]);
        }
    }
}
