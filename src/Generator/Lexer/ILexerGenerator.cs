using System.IO;

namespace Generator.Lexer
{
    public interface ILexerGenerator
    {
        void Generate(string TokenSpecificationFile, string targetFile, string targetNamespace);
    }
}
