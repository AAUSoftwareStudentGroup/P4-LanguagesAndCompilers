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
                    if(type == Word.Type.Ignore)
                        break; // Don't read the rest of this line
                    Console.WriteLine("Line: {0}, Word: {1}: {2} Type {3}", line+1, word+1, inputFileContentWords[line][word], type);
                }
            }
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
            else if(inputFile[line][word] == "(")
                return Word.Type.GroupStart;
            else if(inputFile[line][word] == ")")
                return Word.Type.GroupEnd;
            else if(inputFile[line][word] == "->")
                return Word.Type.Equals;
            else if(inputFile[line][word] == "//")
                return Word.Type.Ignore;
            else
                return Word.Type.NameRead;
        }
    }
}
