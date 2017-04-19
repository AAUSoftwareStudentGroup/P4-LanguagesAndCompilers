using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Compiler.Data;
using Compiler.Shared;
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
        public void TestForCorrectTokenGeneration()
        {
            // Initialise Lexer
            Lexer l = new Lexer(AppContext.BaseDirectory + "\\TestFiles\\Tokens.cfg.json");

            // Read from test file
            IEnumerable<Token> tokens = l.Analyse(File.ReadAllText(AppContext.BaseDirectory + "\\TestFiles\\testSourceFile.tang"));
            
            /*
             * Assert that we have 23 tokens in testSourceFile.tang
             * intType identifier = IntLiteral
             * newLine
             * boolType identifier = boolLiteral
             * newLine
             * while ( identifier )
             * indent identifier = identifier + intLiteral
             * dedent newLine eof
             */
            Assert.AreEqual(tokens.Count(), 23);

            // For safety measures, test at random places that the token is of correct name
            Assert.AreEqual(tokens.ElementAt(0).Name, "intType");
            Assert.AreEqual(tokens.ElementAt(4).Name, "newLine");
            Assert.AreEqual(tokens.ElementAt(10).Name, "while");
            Assert.AreEqual(tokens.ElementAt(13).Name, ")");
            Assert.AreEqual(tokens.ElementAt(16).Name, "=");
            Assert.AreEqual(tokens.ElementAt(22).Name, "eof");

        }

        [TestMethod]
        // Test if attributes are given correctly, e.g. singleline and row/column
        public void TestForCorrectTokenAttributes()
        {
            // Initialise Lexer
            Lexer le = new Lexer(AppContext.BaseDirectory + "\\TestFiles\\Tokens.cfg.json");

            // Read from another file, tokens should be SimpleType Identifier Assign Number eof (int16 a = 1)
            IEnumerable<Token> tokens = le.Analyse(File.ReadAllText(AppContext.BaseDirectory + "\\TestFiles\\testSourceFile.tang"));

            // Assign should be at row 0 and column 8 since there are 8 symbols until '=' is hit
            Assert.AreEqual(tokens.ElementAt(2).Row, 0);
            Assert.AreEqual(tokens.ElementAt(2).Column, 8);
        }

    }
}
