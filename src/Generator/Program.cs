﻿using Generator.Parsing;
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

            bnf = bnfParser.Parse("Semantic.bnf");

            // var grammarInfo = bnfAnalyzer.Analyze(bnf);

            IParserGenerator generator = new ParserGenerator(bnfAnalyzer);

            Directory.CreateDirectory("../Compiler/Parsing/Generated");
            Directory.CreateDirectory("../Compiler/Data/Generated");
            Directory.CreateDirectory("../Compiler/Visitors/Generated");

            // ClassType parserClass = generator.GenerateParserClass(bnf, "Compiler.Data", "Compiler.Parsing");
            ClassType[] parseTreeClasses = generator.GenerateParseTreeClasses(bnf, "Compiler.Data", "Compiler.Visitors");
            ClassType visitorClass = generator.GenerateVisitorClass(bnf, "Compiler.Data", "Compiler.Visitors");

            IClassGenerator classGenerator = new ClassGenerator();

            // classGenerator.Generate(parserClass, $"../Compiler/Parsing/Generated/{parserClass.Identifier.Split('<')[0]}.cs");

            classGenerator.Generate(visitorClass, $"../Compiler/Visitors/Generated/{visitorClass.Identifier.Split('<')[0]}.cs");

            foreach (var c in parseTreeClasses)
            {
                classGenerator.Generate(c, $"../Compiler/Data/Generated/{c.Identifier.Split('<')[0]}.cs");
            }
        }
    }
}
