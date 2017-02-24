using System.Collections.Generic;
using System.IO;
using System;

using P4.LexicalAnalysis;
using P4.Data;

namespace P4
{
    public class Start {
        public static void Main(string[] args)
        {
            BNF bnf = BNFParser.Parse(); 
            Lexer l = new Lexer();
            AST ast;
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
                }
            }
        }
    }
}
    