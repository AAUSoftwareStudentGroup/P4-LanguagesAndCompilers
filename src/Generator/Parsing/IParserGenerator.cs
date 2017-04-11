using Generator.Class;
using Generator.Grammar;
using System.Collections.Generic;
using System.IO;

namespace Generator.Parsing
{
    public interface IParserGenerator
    {
        ClassType[] GenerateParseTreeClasses(BNF bnf, string dataNamespace, string visitorNamespace);
        ClassType GenerateParserClass(BNF bnf, string dataNamespace, string parserNamespace);
        ClassType GenerateVisitorClass(BNF bnf, string dataNamespace, string visitorNamespace);
    }
}
