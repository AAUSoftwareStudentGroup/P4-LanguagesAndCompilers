using System.IO;
using System;
using Compiler.Parsing;
using Compiler.Preprocessing;
using Compiler.LexicalAnalysis;
using System.Linq;
using Compiler.Error;
using System.Collections.Generic;
using System.Linq;

namespace Compiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string tokensPath = "../../docs/tang.tokens.json";
                string sourcePath = "../../docs/samples/BasicBlink.tang";
                string outputPath = sourcePath + ".c";
                int debugLevel = 0;
                TangCompiler tangCompiler = new TangCompiler();
                if (args.Count() > 0)
                {
                    // First arg is sourcefile.
                    sourcePath = args[0];
                    if (args[0] == "-h" || args[0] == "--help")
                        Console.WriteLine("Usage: " + args[0] + " [SOURCEFILE] [OUTPUTFILE] [TOKENSFILE] [DEBUGLEVEL]");
                }
                if (args.Count() > 1)
                {
                    // Second arg is output name
                    outputPath = args[1];
                }
                if (args.Count() > 2)
                {
                    tokensPath = args[2];
                }
                if (args.Count() > 3)
                {
                    debugLevel = Int32.Parse(args[3]);
                }
                if (args.Count() > 4)
                {
                    throw new ArgumentException("Too many arguments");
                }
                File.WriteAllText(outputPath, tangCompiler.Compile(sourcePath, tokensPath, debugLevel));
            }
            catch (LexicalException exception)
            {
                Console.WriteLine($"Unexpected symbol near {exception.Symbol} in {exception.FileName} line {exception.Row + 1} column {exception.Column + 1}.");
            }
            catch (UnexpectedTokenException exception)
            {
                if (exception.Token.Name == exception.Token.Value)
                {
                    if (exception.Token.FileName != null)
                    {
                        Console.WriteLine($"Unexpected '{exception.Token.Name}' in {exception.Token.FileName} line {exception.Token.Row + 1} column {exception.Token.Column + 1}.");
                    }
                    else
                    {
                        Console.WriteLine($"Unexpected '{exception.Token.Name}' at line {exception.Token.Row + 1} column {exception.Token.Column + 1}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Unexpected {exception.Token.Name} '{exception.Token.Value}' in {exception.Token.FileName} line {exception.Token.Row + 1} column {exception.Token.Column + 1}.");
                }
            }
            catch (Translation.TranslationException exception)
            {
                var err = GetErrors(exception.Error).OrderByDescending(e => e.level).First().error;

                Parsing.Data.Node firstNode = null;

                AST.Data.Node translated = null;

                if (err is RuleError<(Parsing.Data.Node, Translation.SymbolTable.Data.Node), Translation.SymbolTable.Data.Node> s)
                {
                    firstNode = s.From.Item1;
                }
                else if(err is RuleError<(Parsing.Data.Node, Translation.SymbolTable.Data.Node), (AST.Data.Node, Translation.SymbolTable.Data.Node)> main)
                {
                    firstNode = main.From.Item1;
                    translated = main.To.Item1;
                }
                else if(err is RuleError<(Parsing.Data.Node, Translation.SymbolTable.Data.Node, Translation.SymbolTable.Data.Node), AST.Data.Node> t)
                {
                    firstNode = t.From.Item1;
                    translated = t.To;
                }
                else if (err is RuleError<(Parsing.Data.Node, Translation.SymbolTable.Data.Node), Translation.SymbolTable.Data.Node> f)
                {
                    firstNode = f.From.Item1;
                }

                var actualNode = firstNode;

                while (!(firstNode is Parsing.Data.Token))
                {
                    firstNode = firstNode[0];
                }

                var firstToken = firstNode as Parsing.Data.Token;

                string wasString = "";

                if(translated != null)
                {
                    wasString = $" was {translated.Name}";
                }

                string fileStr = "";

                if(firstToken.FileName != null)
                {
                    fileStr = $" in {firstToken.FileName}{wasString}";
                }
                
                Console.WriteLine($"Could not translate '{actualNode}' to {err.ReturnTypes[0]}{wasString}{fileStr} at line {firstToken.Row + 1} column {firstToken.Column + 1}.");
            }
        }

        public static List<(int level, RuleError error)> GetErrors(Error.RuleError error)
        {
            List<(int level, RuleError error)> errors = new List<(int level, RuleError error)>();
            GetErrorsAux(error, 0, errors);
            return errors;
        }

        public static void GetErrorsAux(Error.RuleError error, int level, List<(int level, RuleError error)> errors)
        {
            if(error.IsError)
            {
                errors.Add((level, error));
            }

            foreach (var childError in error.Children)
            {
                if (childError.IsError)
                {
                    GetErrorsAux(childError, level + 1, errors);
                }
            }
        }

        public static void PrintErrorTree(Error.RuleError error)
        {
            PrintErrorTreeAux(error, 0);
        }

        public static void PrintErrorTreeAux(Error.RuleError error, int indent)
        {
            if (error is RuleError<(Parsing.Data.Node, Translation.SymbolTable.Data.Node), (AST.Data.Node, Translation.SymbolTable.Data.Node)> error1)
            {
                if (error.IsError)
                {
                    Console.WriteLine($"{Indent(indent)}Could not translate {error1.From.Item1} to {error1.ReturnTypes[0]} pattern { string.Join(", ", error1.PatternTypes)}");
                }
                else
                {
                    Console.WriteLine($"{Indent(indent)}Translated ({error1.From.Item1}, {error1.From.Item2}) to ({string.Join(", ", error1.ReturnTypes)}) pattern { string.Join(", ", error1.PatternTypes)}");
                }
            }
            else if(error is RuleError<Parsing.Data.Node, AST.Data.Node> error2)
            {
                string patternMsg = $" pattern ({ string.Join(", ", error2.PatternTypes)})";
                if (error.IsError)
                {
                    Console.WriteLine($"{Indent(indent)}Could not translate ({error2.From}) to ({string.Join(", ", error2.ReturnTypes)}) pattern { string.Join(", ", error2.PatternTypes)}");
                }
                else
                {
                    Console.WriteLine($"{Indent(indent)}Translated ({error2.From}) to ({string.Join(", ", error2.ReturnTypes)}) pattern { string.Join(", ", error2.PatternTypes)}");
                }
            }
            else if (error is RuleError<(Parsing.Data.Node, Translation.SymbolTable.Data.Node, Translation.SymbolTable.Data.Node), AST.Data.Node> t)
            {
                string patternMsg = $" pattern ({ string.Join(", ", t.PatternTypes)})";
                if (error.IsError)
                {
                    Console.WriteLine($"{Indent(indent)}Could not translate ({t.From}) to ({string.Join(", ", t.ReturnTypes)}) pattern { string.Join(", ", t.PatternTypes)}");
                }
                else
                {
                    Console.WriteLine($"{Indent(indent)}Translated ({t.From}) to ({string.Join(", ", t.ReturnTypes)}) pattern { string.Join(", ", t.PatternTypes)}");
                }
            }
            else if (error is RuleError<(Parsing.Data.Node, Translation.SymbolTable.Data.Node), Translation.SymbolTable.Data.Node> f)
            {
                string patternMsg = $" pattern ({ string.Join(", ", f.PatternTypes)})";
                if (error.IsError)
                {
                    Console.WriteLine($"{Indent(indent)}Could not translate ({f.From}) to ({string.Join(", ", f.ReturnTypes)}) pattern { string.Join(", ", f.PatternTypes)}");
                }
                else
                {
                    Console.WriteLine($"{Indent(indent)}Translated ({f.From}) to ({string.Join(", ", f.ReturnTypes)}) pattern { string.Join(", ", f.PatternTypes)}");
                }
            }

            foreach (var childError in error.Children)
            {
                PrintErrorTreeAux(childError, indent + 1);
            }
        }

        private static string Indent(int indentLevel)
        {
            return string.Join("", Enumerable.Repeat("    ", indentLevel));
        }
    }
}
