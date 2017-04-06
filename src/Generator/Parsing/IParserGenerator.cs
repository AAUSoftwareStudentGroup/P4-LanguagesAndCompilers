using Generator.Class;
using Generator.Grammar;
using System.Collections.Generic;
using System.IO;

namespace Generator.Parsing
{
    public interface IParserGenerator
    {
        ClassType[] GenerateParseTreeClasses(BNF bnf, string targetNamespace);
        ClassType GenerateParserClass(BNF bnf, string targetNamespace);
    }
}
