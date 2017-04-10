using Generator.Parsing;
using Generator.Grammar;
using System.Collections.Generic;
using System;
using Generator.Class;
using System.IO;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            IBNFAnalyzer bnfAnalyzer = new BNFAnalyzer();

            IBNFParser bnfParser = new BNFParser();

            BNF bnf = new BNF()
            {
                { "S", new List<List<string>>(){ new List<string>(){ "A", "a" } } },
                { "A", new List<List<string>>(){ new List<string>(){ "B", "D" } } },
                { "B", new List<List<string>>(){ new List<string>(){ "b" },
                                                 new List<string>(){ "EPSILON" } } },
                { "D", new List<List<string>>(){ new List<string>(){ "d" },
                                                 new List<string>(){ "EPSILON" } } }
            };

            bnf = bnfParser.Parse("BNFGrammar.bnf");

            var grammarInfo = bnfAnalyzer.Analyze(bnf);

            IParserGenerator generator = new ParserGenerator(bnfAnalyzer);

            Directory.CreateDirectory("../Compiler/Parsing/Generated");
            Directory.CreateDirectory("../Compiler/Data/Generated");

            ClassType[] parserClasses = generator.GenerateParserClasses(bnf, "Compiler.Data.Generated", "Compiler.Parsing.Generated");
            ClassType[] parseTreeClasses = generator.GenerateParseTreeClasses(bnf, "Compiler.Parsing.Generated", "Compiler.Data.Generated");

            IClassGenerator classGenerator = new ClassGenerator();

            foreach (var c in parserClasses)
            {
                classGenerator.Generate(c, $"../Compiler/Parsing/Generated/{c.Identifier.Split('<')[0]}.cs");
            }

            foreach (var c in parseTreeClasses)
            {
                classGenerator.Generate(c, $"../Compiler/Data/Generated/{c.Identifier.Split('<')[0]}.cs");
            }
        }
    }
}
