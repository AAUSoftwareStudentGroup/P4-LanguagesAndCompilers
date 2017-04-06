using System.IO;
using System.Collections.Generic;
using Generator.BNF;

namespace Generator.AST
{
    public class ASTGenerator : IASTGenerator
    {
        public void Generate(string formationRulesFile, string targetDirectory, string targetNamespace) 
        {
            Dictionary<string, List<List<string>>> bnf = BNFParser.Parse(formationRulesFile);
        }
    }
}
