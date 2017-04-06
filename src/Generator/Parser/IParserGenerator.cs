using System.Collections.Generic;
using System.IO;

namespace Generator.Parser
{
    public interface IParserGenerator
    {
        void Generate(string inputBNFGrammarFile, string targetDirectory, string targetNamespace);
        void Generate(Dictionary<string, string[][]> bnf, string targetDirectory, string targetNamespace);
    }
}
