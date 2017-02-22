using System;

namespace bnf_parser
{
    class Word
    {
        public enum Type {
            NameRead, // Name,, but not on left side of Equals. Expecting to read the name
            NameSet, // Name, as above, but on the left side on an Equals. Expecting to set the name
            String, // Strings in quotes
            Or, // |
            Comment, // Comment
            Equals // ::=
            };
        public static Type DetectWordType(int line, int word, String[][] inputFile) {
            // Check if this is the first word on a line and the last word on the last line wasn't \
            if(word == 0 && (line == 0 || inputFile[line-1][inputFile[line-1].Length-1] != @"\"))
                return Type.NameSet;
            else if(inputFile[line][word].StartsWith(@"<")) // This is a name we expect to read
                return Type.NameRead;
            else if(inputFile[line][word].StartsWith("\"") || inputFile[line][word].StartsWith("'")) // This is a constant string
                return Type.String;
            else if(inputFile[line][word].StartsWith("|"))
                return Type.Or;
            else if(inputFile[line][word] == "::=")
                return Type.Equals;
            else
                throw new SyntaxErrorException(line+1, word+1, inputFile[line][word]);
        }

        public Type type;
        public Word(Type type) {
            this.type = type;
        }
    }
}
