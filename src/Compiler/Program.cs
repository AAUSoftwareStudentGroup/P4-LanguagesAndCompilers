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

            var tokens = lexer.Analyse(File.ReadAllText("../../docs/samples/Register.tang"));

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

            var astTranslator = new Translation.ProgramToAST.ProgramToASTTranslator();
            AST.Data.AST ast = astTranslator.Translatep(parseTree) as AST.Data.AST;
            var astLines = ast.Accept(new AST.Visitors.TreePrintVisitor());
            foreach (var line in astLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            var cTranslator = new Translation.ASTToC.ASTToCTranslator();
            C.Data.C c = cTranslator.Translate(ast) as C.Data.C;
            var cLines = c.Accept(new C.Visitors.TreePrintVisitor());
            foreach (var line in cLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            var cStr = c.Accept(new C.Visitors.TextPrintVisitor());
            foreach (var term in cStr)
            {
                Console.Write(term.Replace("$",":").Replace(";", ";\n"));
                Console.Write(" ");
            }

            Console.WriteLine();

            //Todo

        }
    }

}
