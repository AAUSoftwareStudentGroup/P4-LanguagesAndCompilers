﻿using System.IO;
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
            Console.WriteLine("Compiler running");
            DateTime tStart = DateTime.Now;
            DateTime t1 = DateTime.Now;
            Lexer lexer = new Lexer(args.Length == 3 ? args[2] : "../../docs/tang.tokens.json");
            int DebugLevel = 2;

            string file = "../../docs/samples/Register.tang";

            if (args.Length > 0)
            {
                file = args[0];
            }

            Console.WriteLine("Running Lexer");

            try
            {
                var tokens = lexer.Analyse(File.ReadAllText(file));

                Console.WriteLine("Lexer on main: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
                t1 = DateTime.Now;
                if (args.Length == 0 && DebugLevel > 0)
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
                if (args.Length == 0 && DebugLevel > 0)
                {
                    Console.WriteLine("Tokens with imports:");
                    Console.WriteLine(string.Join(" ", tokens.Select(t => t.Name)));

                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("");
                }

                Console.WriteLine("Running Parser");
                ProgramParser parser = new ProgramParser();
                var tokenEnumerator = tokens.Select(t => new Parsing.Data.Token() { Name = t.Name, Value = t.Value, FileName = t.FileName, Row = t.Row, Column = t.Column }).GetEnumerator();
                tokenEnumerator.MoveNext();
                var parseTree = parser.ParseProgram(tokenEnumerator);
                Console.WriteLine("Parser: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
                t1 = DateTime.Now;
                var parseTreeLines = parseTree.Accept(new Parsing.Visitors.TreePrintVisitor());
                if (args.Length == 0 && DebugLevel >= 2)
                {
                    {
                        foreach (var line in parseTreeLines)
                        {
                            Console.WriteLine(line);
                        }


                        Console.WriteLine("");
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("");
                        Console.WriteLine("Running Ast Translator");
                        var astTranslator = new Translation.ProgramToAST.ProgramToASTTranslator();
                        AST.Data.AST ast = astTranslator.Translatep(parseTree) as AST.Data.AST;
                        if (ast == null)
                        {
                            throw new Translation.TranslationException(astTranslator.RuleError);
                        }
                        Console.WriteLine("tangToAST: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
                        t1 = DateTime.Now;
                        var astLines = ast.Accept(new AST.Visitors.TreePrintVisitor());

                        if (args.Length == 0 && DebugLevel > 0)
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
                        Console.WriteLine("astToC: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
                        t1 = DateTime.Now;
                        var cLines = c.Accept(new C.Visitors.TreePrintVisitor());
                        var cStr = c.Accept(new C.Visitors.TextPrintVisitor());
                        if (args.Length == 0)
                        {
                            foreach (var line in cLines)
                            {
                                Console.WriteLine(line);
                            }

                            Console.WriteLine("");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("");

                            foreach (var term in cStr)
                            {
                                Console.WriteLine(term);
                            }

                            Console.WriteLine();
                        }

                        Console.WriteLine("Writing to file");
                        File.WriteAllLines(args.Length == 2 ? args[1] : "../../docs/samples/compiled/" + file.Replace("\\", " /").Split('/').Last().Split('.').First() + ".c", cStr);
                    }
                }
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
                //foreach (var err in GetUniqueErrors(exception.Error))
                //{
                //    Console.WriteLine(err.message);
                //}
                var err = (GetErrors(exception.Error).OrderByDescending(e => e.level).First().error as RuleError<(Parsing.Data.Node, Translation.SymbolTable.Data.Node), (AST.Data.Node, Translation.SymbolTable.Data.Node)>);

                var first = err.From.Item1;

                while (!(first is Parsing.Data.Token))
                {
                    first = first[0];
                }

                var firstToken = first as Parsing.Data.Token;

                if (firstToken.FileName != null)
                {
                    Console.WriteLine($"Could not translate '{err.From.Item1}' to {err.ReturnTypes[0]} in {firstToken.FileName} line {firstToken.Row + 1} column {firstToken.Column + 1}.");
                }
                else
                {
                    Console.WriteLine($"Could not translate '{err.From.Item1}' to {err.ReturnTypes[0]} at line {firstToken.Row + 1} column {firstToken.Column + 1}.");
                }

                //PrintErrorTree(exception.Error);
                //PrintErrorTree(exception.Error);
                //Console.WriteLine(GetUniqueErrors(exception.Error).OrderBy(e => e.message.Replace("to", "æ").Split('æ')[0].Length).First().message);
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
                    Console.WriteLine($"{Indent(indent)}Could not translate ({error1.From.Item1}, {error1.From.Item2}) to ({string.Join(", ", error1.ReturnTypes)}) pattern { string.Join(", ", error1.PatternTypes)}");
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
