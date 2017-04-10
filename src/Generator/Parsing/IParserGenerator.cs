using Generator.Class;
using Generator.Grammar;
using System.Collections.Generic;
using System.IO;

namespace Generator.Parsing
{
    public interface IParserGenerator
    {
        ClassType[] GenerateParseTreeClasses(BNF bnf, string dataNameSpace, string visitorNameSpace);
        ClassType GenerateParserClass(BNF bnf, string dataNameSpace, string parserNamespace);
        ClassType GenerateVisitorClass(BNF bnf, string dataNameSpace, string visitorNamespace);
    }
}
