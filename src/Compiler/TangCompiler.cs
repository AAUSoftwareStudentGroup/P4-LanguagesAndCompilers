using Compiler.LexicalAnalysis;
using Compiler.Parsing;
using Compiler.Preprocessing;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compiler
{
    public class TangCompiler : ITangCompiler
    {
        /*
            DebugLevel rules how deep the debug-level is. 
            Every level outputs everything the higher level does, so level 2 outputs everything level 1 does
                Level 0: No output at all
                Level 1: Outputs when it's doing what and how fast
                Level 2: Outputs everything
        */
        public string Compile(string sourcePath, string tokensJsonPath="../../docs/tang.tokens.json", int DebugLevel=0)
        {
            return Compile(File.ReadAllText(sourcePath), Path.GetDirectoryName(sourcePath)+"/", File.ReadAllText(tokensJsonPath), DebugLevel);
        }
        public string Compile(string source, string path, string tokensJson, int DebugLevel=0)
        {
            /*
            System.Console.WriteLine("SOURCE: \n\n\n" + source);
            System.Console.WriteLine("PATH: \n\n\n" + path);
            System.Console.WriteLine("TOKENSJSON: \n\n\n" + tokensJson);
            System.Console.WriteLine("DEBUGLEVEL: \n\n\n" + DebugLevel);
            */
            if(DebugLevel >= 1)
                Console.WriteLine("Compiler running");
            DateTime tStart = DateTime.Now;
            DateTime t1 = DateTime.Now;
            Lexer lexer = new Lexer(tokensJson);

            if(DebugLevel >= 1)
                Console.WriteLine("Running Lexer");
            var tokens = lexer.Analyse(source);

            if(DebugLevel >= 1) {
                foreach(Token t in tokens)
                {
                    Console.WriteLine(t.Name);
                }
            }

            if(DebugLevel >= 1)
                Console.WriteLine("Lexer on main: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            if (DebugLevel >= 2)
            {
                Console.WriteLine(string.Join(" ", tokens.Select(t => t.Name)));

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            if(DebugLevel >= 1)
                Console.WriteLine("Running Preprocessor");
            Preprocessor preprocessor = new Preprocessor();
            tokens = preprocessor.Process(lexer, path, tokens);

            if(DebugLevel >= 1)
                Console.WriteLine("Preprocessor: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;           
            if (DebugLevel >= 2)
            {
                Console.WriteLine("Tokens with imports:");
                Console.WriteLine(string.Join(" ", tokens.Select(t => t.Name)));

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            if(DebugLevel >= 1)
                Console.WriteLine("Running Parser");
            ProgramParser parser = new ProgramParser();
            var tokenEnumerator = tokens.Select(t => new Parsing.Data.Token() { Name = t.Name, Value = t.Value, FileName = t.FileName, Row = t.Row, Column = t.Column }).GetEnumerator();
            tokenEnumerator.MoveNext();
            var parseTree = parser.ParseProgram(tokenEnumerator);
            if(DebugLevel >= 1)
                Console.WriteLine("Parser: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            var parseTreeLines = parseTree.Accept(new Parsing.Visitors.TreePrintVisitor());
            if (DebugLevel >= 2)
            {
                foreach (var line in parseTreeLines)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }
            if(DebugLevel >= 1)
                Console.WriteLine("Running Ast Translator");
            var astTranslator = new Translation.ProgramToAST.ProgramToASTTranslator();
            AST.Data.AST ast = astTranslator.Translatep(parseTree) as AST.Data.AST;
            if (ast == null)
            {
                throw new Translation.TranslationException(astTranslator.RuleError);
            }
            if (DebugLevel >= 1)
                Console.WriteLine("tangToAST: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            var astLines = ast.Accept(new AST.Visitors.TreePrintVisitor());
            if (DebugLevel >= 2)
            {
                foreach (var line in astLines)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            if(DebugLevel >= 1)
                Console.WriteLine("Running C Translator");
            var cTranslator = new Translation.ASTToC.ASTToCTranslator();
            C.Data.C c = cTranslator.Translate(ast) as C.Data.C;
            if(DebugLevel >= 1)
                Console.WriteLine("astToC: " + DateTime.Now.Subtract(t1).TotalMilliseconds + " ms");
            t1 = DateTime.Now;
            
            var cLines = c.Accept(new C.Visitors.TreePrintVisitor());
            
            if (DebugLevel >= 2)
            {
                foreach (var line in cLines)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("");
            }

            var cStr = c.Accept(new C.Visitors.TextPrintVisitor());
            if(DebugLevel >= 1)
            {

                foreach (var term in cStr)
                {
                    Console.WriteLine(term);
                }

                Console.WriteLine();
            }

            if(DebugLevel >= 1)
                Console.WriteLine("Compiler run-time: " + DateTime.Now.Subtract(tStart).TotalMilliseconds + " ms" );
            return string.Join("\n", cStr);
            /*// File path relative to where the debug file is located which is in a land far, far away
            Lexer lexer = new Lexer(AppContext.BaseDirectory + "/../../../../../docs/tang.tokens.json");
            
            var tokens = lexer.Analyse(source);
            Preprocessor preprocessor = new Preprocessor();
            tokens = preprocessor.Process(lexer, tokens);
            ProgramParser parser = new ProgramParser();
            var tokenEnumerator = tokens.Select(t => new Parsing.Data.Token() { Name = t.Name, Value = t.Value }).GetEnumerator();
            tokenEnumerator.MoveNext();
            var parseTree = parser.ParseProgram(tokenEnumerator);
            var astTranslator = new Translation.ProgramToAST.ProgramToASTTranslator();
            AST.Data.AST ast = astTranslator.Translatep(parseTree) as AST.Data.AST;
            var cTranslator = new Translation.ASTToC.ASTToCTranslator();
            C.Data.C c = cTranslator.Translate(ast) as C.Data.C;
            var cStr = c.Accept(new C.Visitors.TextPrintVisitor());

            return string.Join("\n", cStr);*/
        }
    }
}
