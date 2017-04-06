using System;
using System.Collections.Generic;
using System.IO;

namespace Generator.AST
{
    public class ASTGenerator : IASTGenerator
    {
        public void Generate(string formationRulesFile, string targetDirectory, string targetNamespace) 
        {
            
        }

        public void Generate(Dictionary<string, string[][]> bnf, string targetDirectory, string targetNamespace)
        {
            throw new NotImplementedException();
        }
    }
}
