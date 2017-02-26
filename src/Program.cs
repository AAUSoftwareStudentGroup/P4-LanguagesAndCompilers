using System.Collections.Generic;
using System.IO;
using System;
using Compiler.LexicalAnalasis;
using Compiler.Data;

namespace Compiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bnf bnf = BnfParser.Parse();
            Lexer l = new Lexer();
            Tree<string> ast;
            /*
            // List all terminals
            foreach(Symbol s in bnf.terminals)
            {
                Console.WriteLine(s.name);
            }
            return;
             */
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
                    // Console.WriteLine(ast.PrintPretty());
                }
            }
        }
    }
}
