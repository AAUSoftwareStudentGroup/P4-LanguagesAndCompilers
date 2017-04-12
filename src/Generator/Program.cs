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

            var ast = bnfParser.Parse("Semantic.bnf");

            var bnf = bnfParser.Parse("BNFGrammar.bnf");

            // var grammarInfo = bnfAnalyzer.Analyze(bnf);

            string ASTPath = "../Compiler/Data/AST/Generated";

            Console.WriteLine(1);
            IParserGenerator generator = new ParserGenerator(bnfAnalyzer);

			if (Directory.Exists(ASTPath))
            {
				Directory.Delete(ASTPath, true);
            }

			Console.WriteLine(2);

            string ASTVistorPath = "../Compiler/Visitors/AST/Generated";

			if (Directory.Exists(ASTVistorPath))
            {
				Directory.Delete(ASTVistorPath, true);
            }

			Console.WriteLine(3);
            string parserString = "../Compiler/Parsing/Generated";  

			if (Directory.Exists(parserString))
            {
				Directory.Delete(parserString, true);
            }

            Console.WriteLine(4);
            string parseTree = "../Compiler/Data/ParseTree/Generated";
			if (Directory.Exists(parseTree))
            {
				Directory.Delete(parseTree, true);
            }

			Console.WriteLine(5);

            string parseTreeVisitor = "../Compiler/Visitors/ParseTree/Generated";
			if (Directory.Exists(parseTreeVisitor))
            {
				Directory.Delete(parseTreeVisitor, true);
            }


            Directory.CreateDirectory(ASTPath);
            Directory.CreateDirectory(ASTVistorPath);
            Directory.CreateDirectory(parserString);
			Directory.CreateDirectory(parseTree);
            Directory.CreateDirectory(parseTreeVisitor);

            ClassType parserClass = generator.GenerateParserClass(bnf, "Compiler.Data.ParseTree", "Compiler.Visitors.ParseTree");
            ClassType[] parseTreeClasses = generator.GenerateParseTreeClasses(bnf, "Compiler.Data.ParseTree", "Compiler.Visitors.ParseTree");
            ClassType bnfVisitorClass = generator.GenerateVisitorClass(ast, "Compiler.Data.Parsetree", "Compiler.Visitors.ParseTree");

            ClassType[] AstClasses = generator.GenerateParseTreeClasses(ast, "Compiler.Data.AST", "Compiler.Visitors.AST");
            ClassType visitorClass = generator.GenerateVisitorClass(ast, "Compiler.Data.AST", "Compiler.Visitors.AST");

            IClassGenerator classGenerator = new ClassGenerator();

            classGenerator.Generate(parserClass, parserString + $"/{parserClass.Identifier.Split('<')[0]}.cs");

			classGenerator.Generate(visitorClass, ASTVistorPath + $"/{visitorClass.Identifier.Split('<')[0]}.cs");

			classGenerator.Generate(bnfVisitorClass, parseTreeVisitor + $"/{bnfVisitorClass.Identifier.Split('<')[0]}.cs");

            foreach (var c in AstClasses)
            {
                classGenerator.Generate(c, ASTPath + $"/{c.Identifier.Split('<')[0]}.cs");
            }

            foreach (var c in parseTreeClasses)
            {
				classGenerator.Generate(c, parseTree + $"/{c.Identifier.Split('<')[0]}.cs");
            }
        }
    }
}
