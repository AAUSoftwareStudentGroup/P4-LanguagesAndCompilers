using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Compiler.Data;
using Compiler.LexicalAnalysis;
using System.Linq;

namespace Compiler.Tests
{                       // For future reference http://xunit.github.io/docs/comparisons.html
    [TestClass]
    public class LexerTests
    {
        // Perhaps have input file here
        // Run Lexer will result in a list of lexer rules
        // Lexer.Analyse(string source) will produce the tokens, we need the source though

        // String source = arg;
        // IEnumerable<Token> tokens = l.Analyse(File.ReadAllText(arg));

        //         Lexer l = new Lexer();
        //         if(args.Length == 0)
        //             args = new string[] { "sourceFileExample.tang" };
        //         foreach (string arg in args)
        //         {
        //             if (File.Exists(arg))
        //             {
        //                 // read File
        //                 String source = arg;
        //                 IEnumerable<Token> tokens = l.Analyse(File.ReadAllText(arg));







        [TestMethod]
        public void TestForCorrectTokenGeneration()
        {
            // For some input file, check if it produces the correct tokens by accessing the enumerator (maybe assert in foreach?)

            Lexer l = new Lexer();

            IEnumerable<Token> tokens = l.Analyse(File.ReadAllText("TestFiles/sourceFileExample.tang"));

            //List all token in source file
            foreach (Token t in tokens)
            {
                Console.WriteLine(t);
            }



        }


        [TestMethod]
        public void TestForCorrectTokenAttributes()
        {
            // Test if attributes are given correctly, e.g. singleline and row/column
            // Access the attributes of specific generated tokens and assert that they are correct
            Assert.AreEqual(2, 2);
        }
    }
}
