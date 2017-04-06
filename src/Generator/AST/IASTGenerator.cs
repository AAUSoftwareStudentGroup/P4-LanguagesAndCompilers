using System.Collections.Generic;
using System.IO;

namespace Generator.AST
{
    public interface IASTGenerator
    {
        void Generate(string inputBNFGrammarFile, string targetDirectory, string targetNamespace);
        void Generate(Dictionary<string, string[][]> bnf, string targetDirectory, string targetNamespace);
    }
}
