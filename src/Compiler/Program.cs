using System.IO;
using System;
using Compiler.Parsing;
using Compiler.LexicalAnalysis;
using System.Linq;

namespace Compiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Lexer lexer = new Lexer("../../docs/tang.tokens.json");

            var tokens = lexer.Analyse(File.ReadAllText("../../docs/samples/Empty.tang"));

            if (args.Any())
            {
                tokens = lexer.Analyse(File.ReadAllText(args[0]));
            }

            Console.WriteLine(string.Join(" ", tokens.Select(t => t.Name)));

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            ProgramParser parser = new ProgramParser();
            var tokenEnumerator = tokens.Select(t => new Parsing.Data.Token() { Name = t.Name, Value = t.Value }).GetEnumerator();
            tokenEnumerator.MoveNext();
            var parseTree = parser.ParseProgram(tokenEnumerator);
            var parseTreeLines = parseTree.Accept(new Parsing.Visitors.TreePrintVisitor());
            foreach (var line in parseTreeLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            var astConverter = new Translation.ProgramToAST.ProgramToASTTranslator();
            AST.Data.AST ast = astConverter.Translatep(parseTree) as AST.Data.AST;
            var astLines = ast.Accept(new AST.Visitors.TreePrintVisitor());
            foreach (var line in astLines)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
            //Todo

        }
    }

}
