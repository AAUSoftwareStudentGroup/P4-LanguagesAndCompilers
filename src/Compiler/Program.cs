using System.Collections.Generic;
using System.IO;
using System;
using Compiler.Data;
using Compiler.LexicalAnalysis;
using Compiler.Parsing.BnfParsing;
using System.Linq;

namespace Compiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            Bnf bnf = BnfParser.Parse();
            foreach (var p in bnf.Productions)
            {
                Console.WriteLine($"First({p.Name}): {String.Join(", ", p.FirstSet().Select(t => t.Name))}");
                Console.WriteLine($"Follow({p.Name}): {String.Join(", ", p.FollowSet(bnf).Select(t => t.Name))}");
                Console.WriteLine();
            }
            string error;
			if(bnf.IsLL1(out error)) {
    			Console.WriteLine("Grammar is LL(1)");
            }
            else {
                System.Console.WriteLine("Grammar is NOT LL(1)");
                System.Console.WriteLine(error);
            }
            
            Lexer l = new Lexer();
            Data.AST.Root ast = null;
            if(args.Length == 0)
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
            if(ast != null)
            {
                System.Console.WriteLine("Cleaning up the mess");
                Visitor v = new Visitor();
                ast.Accept(v);
                System.Console.WriteLine(ast);
            }
        }

    }

}
