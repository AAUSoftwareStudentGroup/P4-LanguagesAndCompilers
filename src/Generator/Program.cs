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

            ClassType classType = generator.GenerateParserClass(bnf, "Generator.Generated");
            ClassType[] classes = generator.GenerateParseTreeClasses(bnf, "Generator.Generated");

            IClassGenerator classGenerator = new ClassGenerator();

            Directory.CreateDirectory("Generated");

            classGenerator.Generate(classType, $"Generated/{classType.Identifier}.cs");

            foreach (var c in classes)
            {
                classGenerator.Generate(c, $"Generated/{c.Identifier.Split('<')[0]}.cs");
            }

            Parser parser = new Parser();

            var tokens = new List<Token>
            {
                new Token() { Name = "simpleType" },
                new Token() { Name = "identifier" },
                new Token() { Name = "assign" },
                new Token() { Name = "intLiteral" },
                new Token() { Name = "addSub" },
                new Token() { Name = "intLiteral" },
                new Token() { Name = "newline" },
                new Token() { Name = "simpleType" },
                new Token() { Name = "identifier" },
                new Token() { Name = "assign" },
                new Token() { Name = "intLiteral" },
                new Token() { Name = "addSub" },
                new Token() { Name = "intLiteral" },
                new Token() { Name = "multDiv" },
                new Token() { Name = "intLiteral" },
                new Token() { Name = "eof" }
            }.GetEnumerator();

            tokens.MoveNext();

            Node node = parser.ParseProgram(tokens);

            BuildASTVisitor astBuilder = new BuildASTVisitor();

            PrintVisitor printer = new PrintVisitor();

            Console.WriteLine(node.Accept(astBuilder).Accept(printer));

            Console.Read();
        }
    }
}
