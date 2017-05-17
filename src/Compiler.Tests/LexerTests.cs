using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    [TestClass]
    public class LexerTests
    {
        // For future reference http://xunit.github.io/docs/comparisons.html

        [TestMethod]
        // Test if each token generated from a test file generates tokens with correct names
        // A newline is inserted after each scope
        public void GenerateTokensCorrectly()
        {
            // Initialise Lexer
            Lexer l = new Lexer(AppContext.BaseDirectory + "/TestFiles/Tokens.cfg.json");

            // Read from test file
            IEnumerable<Token> tokens = l.Analyse(File.ReadAllText(AppContext.BaseDirectory + "/TestFiles/testSourceFile.tang"));

            /*
             * Assert that we have 26 tokens in testSourceFile.tang
             * int16 identifier = numeral
             * newline
             * bool identifier = true
             * newline
             * while ( identifier == true )
             * indent identifier = identifier + numeral newline
             * dedent newline eof
             */
            Assert.AreEqual(tokens.Count(), 26);

            // For safety measures, test at random places that the token is of correct name
            Assert.AreEqual(tokens.ElementAt(0).Name, "int16");
            Assert.AreEqual(tokens.ElementAt(4).Name, "newline");
            Assert.AreEqual(tokens.ElementAt(10).Name, "while");
            Assert.AreEqual(tokens.ElementAt(13).Name, "==");
            Assert.AreEqual(tokens.ElementAt(16).Name, "indent");
            Assert.AreEqual(tokens.ElementAt(25).Name, "eof");
        }

        [TestMethod]
        // In cases where it is unsure which token to produce, read until match ends and produce a token from that
        public void SplitTokensCorrectly()
        {
            // Initialise Lexer
            Lexer l = new Lexer(AppContext.BaseDirectory + "/TestFiles/Tokens.cfg.json");

            IEnumerable<Token> tokens = l.Analyse("=== 2test");

            Assert.AreEqual(tokens.ElementAt(0).Name, "==");
            Assert.AreEqual(tokens.ElementAt(1).Name, "=");
            Assert.AreEqual(tokens.ElementAt(2).Name, "numeral");
            Assert.AreEqual(tokens.ElementAt(3).Name, "identifier");
            // All programs have a newline and eof token inserted at the end
            Assert.AreEqual(tokens.ElementAt(4).Name, "newline");
            Assert.AreEqual(tokens.ElementAt(5).Name, "eof");
        }


        [TestMethod]
        // Test if attributes are given correctly, e.g. singleline and row/column
        public void GenereteCorrectTokenAttributes()
        {
            // Initialise Lexer
            Lexer le = new Lexer(AppContext.BaseDirectory + "/TestFiles/Tokens.cfg.json");

            // Read from another file, tokens should be SimpleType Identifier Assign Number eof (int16 a = 1)
            IEnumerable<Token> tokens = le.Analyse(File.ReadAllText(AppContext.BaseDirectory + "/TestFiles/testSourceFile.tang"));

            // '=' should be at row 0 and column 8 since there are 8 symbols until '=' is hit
            Assert.AreEqual(tokens.ElementAt(2).Row, 0);
            Assert.AreEqual(tokens.ElementAt(2).Column, 8);

            // 'on' should be at row 1 and column 5
            Assert.AreEqual(tokens.ElementAt(6).Row, 1);
            Assert.AreEqual(tokens.ElementAt(6).Column, 5);
        }

        [TestMethod]
        public void AddExpressionSpecialTestLexer()
        {
            // Initialise Lexer
            Lexer l = new Lexer(AppContext.BaseDirectory + "/TestFiles/Tokens.cfg.json");

            // Read from test file
            IEnumerable<Token> tokens = l.Analyse(File.ReadAllText(AppContext.BaseDirectory + "/TestFiles/AddExpression.tang"));

            /* 
             * int8 a = 1 + 2 + 3
             * should be
             * int8 identifier = numeral + numeral + numeral newline eof
             */
            Assert.AreEqual(tokens.Count(), 10);
            Assert.AreEqual(tokens.ElementAt(2).Name, "=");
            Assert.AreEqual(tokens.ElementAt(4).Name, "+");
            Assert.AreEqual(tokens.ElementAt(7).Name, "numeral");
            Assert.AreEqual(tokens.ElementAt(8).Name, "newline");
            Assert.AreEqual(tokens.ElementAt(9).Name, "eof");
        }
    }
}
