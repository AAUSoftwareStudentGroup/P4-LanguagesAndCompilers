using System.IO;

namespace Generator.Parser
{
    public interface IParserGenerator
    {
        void Generate(string inputBNFGrammarFile, string targetDirectory, string targetNamespace);
    }
}
