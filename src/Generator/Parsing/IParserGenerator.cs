using Generator.Class;
using Generator.Grammar;
using System.Collections.Generic;
using System.IO;

namespace Generator.Parsing
{
    public interface IParserGenerator
    {
        ClassType[] GenerateParseTreeClasses(BNF bnf, string visitorName, string dataNamespace, string visitorNamespace);
        ClassType GenerateParserClass(BNF bnf, string parserName, string dataNamespace, string parserNamespace);
        ClassType[] GenerateVisitorClasses(BNF bnf, string visitorName, string dataNamespace, string visitorNamespace);
    }
}
