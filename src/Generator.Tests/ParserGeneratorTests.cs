using Generator.Class;
using Generator.Grammar;
using Generator.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Generator.Tests
{
    [TestClass]
    public class ParserGeneratorTests
    {
        BNF ll1Grammar => new BNF()
        {
            { "S", new string[][] { new string[] { "A", "a" } } },
            { "A", new string[][] { new string[] { "B", "D" } } },
            { "B", new string[][] { new string[] { "b" },
                                    new string[] { "EPSILON" } } },
            { "D", new string[][] { new string[] { "d" },
                                    new string[] { "EPSILON" } } }
        };

        [TestMethod]
        public void ParserGeneratorGenerateParserClass()
        {
            IBNFAnalyzer bnfAnalyzer = new BNFAnalyzer();
            IParserGenerator parserGenerator = new ParserGenerator(bnfAnalyzer);
            ClassType parserClass = parserGenerator.GenerateParserClass(ll1Grammar, "Compiler.Parser");

            string[] expectedMethods = new string[] { "ParseS", "ParseA", "ParseB", "ParseD", "ParseTerminal" };

            var actualMethods = parserClass.Methods.Select(m => m.Identifier);

            Assert.AreEqual(expectedMethods.Length, expectedMethods.Intersect(actualMethods).Count());
        }
    }
}
