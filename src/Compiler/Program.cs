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

            var tokens = lexer.Analyse(File.ReadAllText("../../docs/samples/Declaration.tang"));

            if (args.Any())
            {
                tokens = lexer.Analyse(File.ReadAllText(args[0]));
            }

            Console.WriteLine(string.Join(", ", tokens.Select(t => t.Name)));

            ProgramParser parser = new ProgramParser();
            var tokenEnumerator = tokens.Select(t => new Parsing.Data.Token() { Name = t.Name, Value = t.Value }).GetEnumerator();
            tokenEnumerator.MoveNext();
            var programTokens = parser.ParseProgram(tokenEnumerator);
            var ASTConverter = new Translation.ProgramToAST.ProgramToASTTranslator();
            ASTConverter.Translatep(programTokens as Parsing.Data.Program);

            Console.ReadKey();
            //Todo

        }
    }

}
