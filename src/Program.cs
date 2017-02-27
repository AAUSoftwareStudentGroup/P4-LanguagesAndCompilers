using System.Collections.Generic;
using System.IO;
using System;

using Compiler.LexicalAnalysis;
using Compiler.Data;
using System.Linq;

namespace Compiler
{
    public class Start {
        public static void Main(string[] args)
        {
            Bnf bnf = BnfParser.Parse();
			var flag = bnf.IsLL1();
			Console.WriteLine("flag: " + flag);
			Console.ReadKey();
            Lexer l = new Lexer();
            Tree<string> ast;

            foreach (string arg in args)
            {
                if(File.Exists(arg)) {
                    // read File
                    String source = arg;
                    IEnumerable<Token> tokens = l.Analyse(File.ReadAllText(arg));
                    
                    // List all token in source file
                    foreach(Token t in tokens)
                    {
                        System.Console.WriteLine(t);
                    }
                    // return;
                    
                    ast = bnf.ParseTokenStream(tokens);
                    Console.WriteLine(ast);
					Console.ReadKey();
                    // Console.WriteLine(ast.PrintPretty());
                }
            }
        }

    }

}
    