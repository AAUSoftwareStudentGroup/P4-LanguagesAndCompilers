using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Generator.BNF;
using System.Linq;

namespace Generator.Tests
{
    [TestClass]
    class BNFAnalyzerTests
    {
        [TestMethod]
        public void BNFAnalyzerGetFirstSet()
        {
            IBNFAnalyzer bnfAnalyzer = new BNFAnalyzer();

            var firstSets = bnfAnalyzer.GetFirstSets(new Dictionary<string, string[][]>()
            {
                { "S", new string[][]{ new string[] { "A", "a" } } },
                { "A", new string[][]{ new string[] { "B", "D" } } },
                { "B", new string[][]{ new string[] { "b" },
                                       new string[] { "EPSILON" } } },
                { "D", new string[][]{ new string[] { "d" },
                                       new string[] { "EPSILON" } } }
            });

            string[] expected = new string[] { "a", "b", "d" };

            Assert.AreEqual(expected.Length, firstSets["S"].Intersect(expected).Count());
        }
    }
}
