using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using Compiler.Data;
//using Compiler.Shared;
using Compiler.LexicalAnalysis;
using System.Linq;
using System.Diagnostics;

namespace Compiler.Tests
{
    public class LexerTests
    {
        // For future reference http://xunit.github.io/docs/comparisons.html
// Utterly useless tests
//         [Fact]
//         // Test if each token generated from a test file generates tokens with correct names
//         // A newline is inserted after each scope
//         public void GenerateTokensCorrectly()
//         {
//             // Initialise Lexer
//             Lexer l = new Lexer(File.ReadAllText(AppContext.BaseDirectory + "Tokens.cfg.json"));

//             // Read from test file
//             IEnumerable<Token> tokens = l.Analyse(File.ReadAllText(AppContext.BaseDirectory + "/Testfiles/tang/testSourceFile.tang"));

//             /*
//              * Assert that we have 26 tokens in testSourceFile.tang
//              * int16 identifier = numeral
//              * newline
//              * bool identifier = true
//              * newline
//              * while ( identifier == true )
//              * indent identifier = identifier + numeral newline
//              * dedent newline eof
//              */
//             Assert.Equal(tokens.Count(), 26);

//             // For safety measures, test at random places that the token is of correct name
//             Assert.Equal(tokens.ElementAt(0).Name, "int16");
//             Assert.Equal(tokens.ElementAt(4).Name, "newline");
//             Assert.Equal(tokens.ElementAt(10).Name, "while");
//             Assert.Equal(tokens.ElementAt(13).Name, "==");
//             Assert.Equal(tokens.ElementAt(16).Name, "indent");
//             Assert.Equal(tokens.ElementAt(25).Name, "eof");
//         }

//         [Fact]
//         // In cases where it is unsure which token to produce, read until match ends and produce a token from that
//         public void SplitTokensCorrectly()
//         {
//             // Initialise Lexer
//             Lexer l = new Lexer(AppContext.BaseDirectory + "/Testfiles/tang/Tokens.cfg.json");

//             IEnumerable<Token> tokens = l.Analyse("=== 2test");

//             Assert.Equal(tokens.ElementAt(0).Name, "==");
//             Assert.Equal(tokens.ElementAt(1).Name, "=");
//             Assert.Equal(tokens.ElementAt(2).Name, "numeral");
//             Assert.Equal(tokens.ElementAt(3).Name, "identifier");
//             // All programs have a newline and eof token inserted at the end
//             Assert.Equal(tokens.ElementAt(4).Name, "newline");
//             Assert.Equal(tokens.ElementAt(5).Name, "eof");
//         }


//         [Fact]
//         // Test if attributes are given correctly, e.g. singleline and row/column
//         public void GenereteCorrectTokenAttributes()
//         {
//             // Initialise Lexer
//             Lexer le = new Lexer(AppContext.BaseDirectory + "/Testfiles/tang/Tokens.cfg.json");

//             // Read from another file, tokens should be SimpleType Identifier Assign Number eof (int16 a = 1)
//             IEnumerable<Token> tokens = le.Analyse(File.ReadAllText(AppContext.BaseDirectory + "/Testfiles/tang/testSourceFile.tang"));

//             // '=' should be at row 0 and column 8 since there are 8 symbols until '=' is hit
//             Assert.Equal(tokens.ElementAt(2).Row, 0);
//             Assert.Equal(tokens.ElementAt(2).Column, 8);

//             // 'on' should be at row 1 and column 5
//             Assert.Equal(tokens.ElementAt(6).Row, 1);
//             Assert.Equal(tokens.ElementAt(6).Column, 5);
//         }

//         [Fact]
//         public void AddExpressionSpecialTestLexer()
//         {
//             // Initialise Lexer
//             Lexer l = new Lexer(AppContext.BaseDirectory + "/Testfiles/tang/Tokens.cfg.json");

//             // Read from test file
//             IEnumerable<Token> tokens = l.Analyse(File.ReadAllText(AppContext.BaseDirectory + "/Testfiles/tang/AddExpression.tang"));

//             /* 
//              * int8 a = 1 + 2 + 3
//              * should be
//              * int8 identifier = numeral + numeral + numeral newline eof
//              */
//             Assert.Equal(tokens.Count(), 10);
//             Assert.Equal(tokens.ElementAt(2).Name, "=");
//             Assert.Equal(tokens.ElementAt(4).Name, "+");
//             Assert.Equal(tokens.ElementAt(7).Name, "numeral");
//             Assert.Equal(tokens.ElementAt(8).Name, "newline");
//             Assert.Equal(tokens.ElementAt(9).Name, "eof");
//         }
    }
}
