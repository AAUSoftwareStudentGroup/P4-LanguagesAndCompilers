using Generator.AST;
using Generator.BNF;
using System.IO;
using System;
using System.Collections.Generic;
using Generator.Class;

namespace Generator.Parser
{
    public class ParserGenerator : IParserGenerator
    {
        IBNFParser _bnfParser;
        IClassGenerator _classGenerator;

        ParserGenerator(IBNFParser bnfParser, IClassGenerator classGenerator)
        {
            _bnfParser = bnfParser;
            _classGenerator = classGenerator;
        }

        public void Generate(string inputBNFGrammarFile, string targetDirectory, string targetNamespace) 
        {
            var bnf = _bnfParser.ParseBNF(inputBNFGrammarFile);
            Generate(bnf, targetDirectory, targetNamespace);
        }

        public void Generate(Dictionary<string, string[][]> bnf, string targetDirectory, string targetNamespace)
        {
            List<ClassType> classes = new List<ClassType>();

            

        }
    }
}
