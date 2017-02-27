using System.Collections.Generic;
using System.IO;
using System;
using Compiler.Data;
using Compiler.LexicalAnalysis;
using System.Linq;
namespace Compiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bnf bnf = BnfParser.Parse();
            foreach (var p in bnf.Productions)
            {
                Console.WriteLine($"First({p.Name}): {String.Join(", ", p.FirstSet().Select(t => t.Name))}");
                Console.WriteLine($"Follow({p.Name}): {String.Join(", ", p.FollowSet(bnf).Select(t => t.Name))}");
                Console.WriteLine();
            }
			var flag = bnf.IsLL1();
			Console.WriteLine("flag: " + flag);
            Lexer l = new Lexer();
            Tree<string> ast;
            args = new string[] { "sourceFileExample.tang" };
            foreach (string arg in args)
            {
                if (File.Exists(arg))
                {
                    // read File
                    String source = arg;
                    IEnumerable<Token> tokens = l.Analyse(File.ReadAllText(arg));

                    // List all token in source file
                    foreach (Token t in tokens)
                    {
                        Console.WriteLine(t);
                    }
                    // return;

                    ast = bnf.ParseTokenStream(tokens);
                    Console.WriteLine(ast);
                    //Console.ReadKey();
                    //Console.WriteLine(ast.PrintPretty());
                }
            }
        }

    }

}
