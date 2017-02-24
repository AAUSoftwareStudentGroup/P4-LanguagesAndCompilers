using System.Collections.Generic;
using System.IO;
using System;

namespace P4.Lexer
{
    public class Start {
        public static void Main(string[] args)
        {
            Lexer l = new Lexer();

            foreach (string arg in args)
            {
                if(File.Exists(arg)) {
                    // read File
                    String source = arg;
                    List<Token> tokens = l.Analyse(File.ReadAllText(arg));
                    foreach( Token t in tokens)
                    {
                        Console.WriteLine($"({t.Name}: {t.Value})");
                    }
                }
            }
        }
    }
}
    