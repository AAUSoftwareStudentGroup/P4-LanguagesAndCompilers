using System.IO;
using System;
using Compiler.Parsing;
using Compiler.Preprocessing;
using Compiler.LexicalAnalysis;
using System.Linq;

namespace Compiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Compiler running");
            DateTime tStart = DateTime.Now;
            DateTime t1 = DateTime.Now;
            Lexer lexer = new Lexer(args.Length == 3 ? args[2] : "../../docs/tang.tokens.json");
            int DebugLevel = 0;

            string file = "../../docs/samples/test2.tang";

            if(args.Length > 0)
            {
                file = args[0];
            }
            Console.WriteLine("Running Lexer");
            var tokens = lexer.Analyse(File.ReadAllText(file));

            foreach(Token t in tokens)
            {
                Console.WriteLine(t.Name);
            }

            Console.WriteLine("Lexer on main: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            if (args.Length == 0 && DebugLevel >= 2)
            {
                Console.WriteLine(string.Join(" ", tokens.Select(t => t.Name)));

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            Console.WriteLine("Running Preprocessor");
            Preprocessor preprocessor = new Preprocessor();
            tokens = preprocessor.Process(lexer, tokens);

            Console.WriteLine("Preprocessor: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;           
            if (args.Length == 0 && DebugLevel >= 2)
            {
                Console.WriteLine("Tokens with imports:");
                Console.WriteLine(string.Join(" ", tokens.Select(t => t.Name)));

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            Console.WriteLine("Running Parser");
            ProgramParser parser = new ProgramParser();
            var tokenEnumerator = tokens.Select(t => new Parsing.Data.Token() { Name = t.Name, Value = t.Value }).GetEnumerator();
            tokenEnumerator.MoveNext();
            var parseTree = parser.ParseProgram(tokenEnumerator);
            Console.WriteLine("Parser: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            var parseTreeLines = parseTree.Accept(new Parsing.Visitors.TreePrintVisitor());
            if (args.Length == 0 && DebugLevel >= 2)
            {
                foreach (var line in parseTreeLines)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            Console.WriteLine("Running Ast Translator");
            var astTranslator = new Translation.ProgramToAST.ProgramToASTTranslator();
            AST.Data.AST ast = astTranslator.Translatep(parseTree) as AST.Data.AST;
            if(DebugLevel >= 2)
                astTranslator.printCounts();
            Console.WriteLine("tangToAST: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            var astLines = ast.Accept(new AST.Visitors.TreePrintVisitor());
            if (args.Length == 0 && DebugLevel >= 2)
            {
                foreach (var line in astLines)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            Console.WriteLine("Running C Translator");
            var cTranslator = new Translation.ASTToC.ASTToCTranslator();
            C.Data.C c = cTranslator.Translate(ast) as C.Data.C;
            if(DebugLevel >= 2)
                cTranslator.printCounts();
            Console.WriteLine("astToC: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            var cLines = c.Accept(new C.Visitors.TreePrintVisitor());
            var cStr = c.Accept(new C.Visitors.TextPrintVisitor());
            if (args.Length == 0 && DebugLevel >= 2)
            {
                foreach (var line in cLines)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            if(args.Length == 0 && DebugLevel >= 1)
            {

                foreach (var term in cStr)
                {
                    Console.WriteLine(term);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Writing to file");
            File.WriteAllLines(args.Length == 2 ? args[1] : "../../docs/samples/compiled/" + file.Replace("\\", " /").Split('/').Last().Split('.').First() + ".c", cStr);
            Console.WriteLine("Compiler run-time: " + DateTime.Now.Subtract(tStart).TotalMilliseconds + " ms" );
        }
    }

}
