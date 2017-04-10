using Generator.Class;
using Generator.Grammar;
using System.Collections.Generic;
using System.IO;

namespace Generator.Parsing
{
    public interface IParserGenerator
    {
        ClassType[] GenerateParseTreeClasses(BNF bnf, string parserNameSpace, string targetNamespace);
        ClassType[] GenerateParserClasses(BNF bnf, string dataNameSpace, string targetNamespace);
    }
}
