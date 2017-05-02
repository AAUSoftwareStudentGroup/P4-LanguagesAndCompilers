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
            DateTime t1 = DateTime.Now;
            Lexer lexer = new Lexer(args.Length == 3 ? args[2] : "../../docs/tang.tokens.json");

            string file = "../../docs/samples/Blink.tang";

            if(args.Length > 0)
            {
                file = args[0];
            }

            var tokens = lexer.Analyse(File.ReadAllText(file));

            Console.WriteLine("Lexer: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            if (args.Length == 0)
            {
                Console.WriteLine(string.Join(" ", tokens.Select(t => t.Name)));

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            ProgramParser parser = new ProgramParser();
            var tokenEnumerator = tokens.Select(t => new Parsing.Data.Token() { Name = t.Name, Value = t.Value }).GetEnumerator();
            tokenEnumerator.MoveNext();
            var parseTree = parser.ParseProgram(tokenEnumerator);
            Console.WriteLine("Parser: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            var parseTreeLines = parseTree.Accept(new Parsing.Visitors.TreePrintVisitor());
            if (args.Length == 0)
            {
                foreach (var line in parseTreeLines)
                {
                    Console.WriteLine(line);
                }


                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            var astTranslator = new Translation.ProgramToAST.ProgramToASTTranslator();
            AST.Data.AST ast = astTranslator.Translatep(parseTree) as AST.Data.AST;
            astTranslator.printCounts();
            Console.WriteLine("tangToAST: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            var astLines = ast.Accept(new AST.Visitors.TreePrintVisitor());
            if (args.Length == 0)
            {
                foreach (var line in astLines)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            var cTranslator = new Translation.ASTToC.ASTToCTranslator();
            C.Data.C c = cTranslator.Translate(ast) as C.Data.C;
            cTranslator.printCounts();
            Console.WriteLine("astToC: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            var cLines = c.Accept(new C.Visitors.TreePrintVisitor());
            var cStr = c.Accept(new C.Visitors.TextPrintVisitor());
            if (args.Length == 0)
            {
                foreach (var line in cLines)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");

                foreach (var term in cStr)
                {
                    Console.WriteLine(term);
                }

                Console.WriteLine();
            }

            File.WriteAllLines(args.Length == 2 ? args[1] : "../../docs/samples/compiled/" + file.Replace("\\", " /").Split('/').Last().Split('.').First() + ".c", cStr);

            //Todo

        }
    }

}
