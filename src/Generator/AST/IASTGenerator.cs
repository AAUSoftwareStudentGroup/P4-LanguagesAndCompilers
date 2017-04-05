using System.IO;

namespace Generator.AST
{
    public interface IASTGenerator
    {
        void Generate(string formationRulesFile, string targetDirectory, string targetNamespace);
    }
}
