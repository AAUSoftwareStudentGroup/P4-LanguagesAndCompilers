using Generator.AST;
using Generator.Lexer;
using Generator.Parsing;
using Generator.Grammar;
using System.Collections.Generic;
using System;
using Generator.Class;
using System.IO;
using Generator.Generated;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            IBNFAnalyzer bnfAnalyzer = new BNFAnalyzer();

            BNF bnf = new BNF()
            {
                { "S", new string[][]{ new string[] { "A", "a" } } },
                { "A", new string[][]{ new string[] { "B", "D" } } },
                { "B", new string[][]{ new string[] { "b" },
                                       new string[] { "EPSILON" } } },
                { "D", new string[][]{ new string[] { "d" },
                                       new string[] { "EPSILON" } } }
            };

            var grammarInfo = bnfAnalyzer.Analyze(bnf);

            IParserGenerator generator = new ParserGenerator(bnfAnalyzer);

            ClassType classType = generator.GenerateParserClass(bnf, "Generator.Generated");
            ClassType[] classes = generator.GenerateParseTreeClasses(bnf, "Generator.Generated");

            IClassGenerator classGenerator = new ClassGenerator();

            Directory.CreateDirectory("Generated");

            classGenerator.Generate(classType, $"Generated/{classType.Identifier}.cs");

            foreach (var c in classes)
            {
                classGenerator.Generate(c, $"Generated/{c.Identifier}.cs");
            }

            Parser parser = new Parser();

            var tokens = new List<Token>
            {
                new Token() { Name = "b" },
                new Token() { Name = "d" },
                new Token() { Name = "a" },
            }.GetEnumerator();

            tokens.MoveNext();

            Node node = parser.ParseS(tokens);

            PrintVisitor printer = new PrintVisitor();

            node.Accept(printer);

            Console.ReadKey();
        }
    }
}
