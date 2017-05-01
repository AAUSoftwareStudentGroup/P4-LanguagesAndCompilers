using Compiler.LexicalAnalysis;
using Compiler.Parsing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compiler
{
    public class TangCompiler : ITangCompiler
    {
        public string Compile(string source)
        {
            // File path relative to where the debug file is located which is in a land far, far away
            Lexer l = new Lexer(AppContext.BaseDirectory + "..\\..\\..\\..\\..\\..\\docs\\tang.tokens.json");
            
            var tokens = l.Analyse(source);
            ProgramParser parser = new ProgramParser();
            var tokenEnumerator = tokens.Select(t => new Parsing.Data.Token() { Name = t.Name, Value = t.Value }).GetEnumerator();
            tokenEnumerator.MoveNext();
            var parseTree = parser.ParseProgram(tokenEnumerator);
            var astTranslator = new Translation.ProgramToAST.ProgramToASTTranslator();
            AST.Data.AST ast = astTranslator.Translatep(parseTree) as AST.Data.AST;
            var cTranslator = new Translation.ASTToC.ASTToCTranslator();
            C.Data.C c = cTranslator.Translate(ast) as C.Data.C;
            var cStr = c.Accept(new C.Visitors.TextPrintVisitor());

            return string.Join("\n", cStr);
        }
    }
}
