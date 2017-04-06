using Generator.AST;
using Generator.Lexer;
using Generator.Parser;
using Generator.BNF;
using System.Collections.Generic;
using System;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            IASTGenerator astGenerator;
            ILexerGenerator lexerGenerator;
            IParserGenerator parserGenerator;
            Dictionary<string, List<List<string>>> RawBNF = new BNFParser().Parse("BNFGrammar.bnf");
        }
    }
}
