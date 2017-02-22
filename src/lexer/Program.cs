using System;
using System.IO;

namespace P4.Lexer 
{
    public class LexerRunner
    {
        public static void Main(string[] args) 
        {
            Lexer l = new Lexer();
            
            foreach(string arg in args)
            {
                if(File.Exists(arg))
                {
                    string source = File.ReadAllText(arg);
                    foreach(Token t in l.Analyse(source))
                    {
                        Console.WriteLine($"{t.Type}: '{t.Value}'");
                    }
                }
            }
        }
    }
}