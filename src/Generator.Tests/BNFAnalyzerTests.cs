using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Generator.Grammar;
using System.Linq;

namespace Generator.Tests
{
    [TestClass]
    public class BNFAnalyzerTests
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
        public void BNFAnalyzerGetFirstSets()
        {
            IBNFAnalyzer bnfAnalyzer = new BNFAnalyzer();

            var firstSets = bnfAnalyzer.GetFirstSets(ll1Grammar);

            string[] expectedS0 = new string[] { "a", "b", "d" };
            Assert.AreEqual(expectedS0.Length, firstSets.ExpansionSets[("S", 0)].Intersect(expectedS0).Count());

            string[] expectedA0 = new string[] { "EPSILON", "b", "d" };
            Assert.AreEqual(expectedA0.Length, firstSets.ExpansionSets[("A", 0)].Intersect(expectedA0).Count());

            string[] expectedB0 = new string[] { "b" };
            Assert.AreEqual(expectedB0.Length, firstSets.ExpansionSets[("B", 0)].Intersect(expectedB0).Count());

            string[] expectedB1 = new string[] { "EPSILON" };
            Assert.AreEqual(expectedB1.Length, firstSets.ExpansionSets[("B", 1)].Intersect(expectedB1).Count());

            string[] expectedD0 = new string[] { "d" };
            Assert.AreEqual(expectedD0.Length, firstSets.ExpansionSets[("D", 0)].Intersect(expectedD0).Count());

            string[] expectedD1 = new string[] { "EPSILON" };
            Assert.AreEqual(expectedD1.Length, firstSets.ExpansionSets[("D", 1)].Intersect(expectedD1).Count());
        }

        [TestMethod]
        public void BNFAnalyzerGetFollowSets()
        {
            IBNFAnalyzer bnfAnalyzer = new BNFAnalyzer();

            var followSets = bnfAnalyzer.GetFollowSets(ll1Grammar, bnfAnalyzer.GetFirstSets(ll1Grammar));

            string[] expectedA = new string[] { "a" };
            Assert.AreEqual(expectedA.Length, followSets["A"].Intersect(expectedA).Count());

            string[] expectedB = new string[] { "a", "d" };
            Assert.AreEqual(expectedB.Length, followSets["B"].Intersect(expectedB).Count());

            string[] expectedD = new string[] { "a" };
            Assert.AreEqual(expectedD.Length, followSets["D"].Intersect(expectedD).Count());
        }

        [TestMethod]
        public void BNFAnalyzerGetPredictSets()
        {
            IBNFAnalyzer bnfAnalyzer = new BNFAnalyzer();

            var predictSets = bnfAnalyzer.GetPredictSets(ll1Grammar, bnfAnalyzer.GetFirstSets(ll1Grammar), bnfAnalyzer.GetFollowSets(ll1Grammar, bnfAnalyzer.GetFirstSets(ll1Grammar)));

            string[] expectedS0 = new string[] { "a", "b", "d" };
            Assert.AreEqual(expectedS0.Length, predictSets[("S", 0)].Intersect(expectedS0).Count());

            string[] expectedA0 = new string[] { "a", "b", "d" };
            Assert.AreEqual(expectedA0.Length, predictSets[("A", 0)].Intersect(expectedA0).Count());

            string[] expectedB0 = new string[] { "b" };
            Assert.AreEqual(expectedB0.Length, predictSets[("B", 0)].Intersect(expectedB0).Count());

            string[] expectedB1 = new string[] { "EPSILON", "d", "a" };
            Assert.AreEqual(expectedB1.Length, predictSets[("B", 1)].Intersect(expectedB1).Count());

            string[] expectedD0 = new string[] { "d" };
            Assert.AreEqual(expectedD0.Length, predictSets[("D", 0)].Intersect(expectedD0).Count());

            string[] expectedD1 = new string[] { "EPSILON", "a" };
            Assert.AreEqual(expectedD1.Length, predictSets[("D", 1)].Intersect(expectedD1).Count());
        }

        [TestMethod]
        public void BNFAnalyzerIsLL1()
        {
            IBNFAnalyzer bnfAnalyzer = new BNFAnalyzer();

            var isLL1 = bnfAnalyzer.IsLL1(ll1Grammar, bnfAnalyzer.GetFirstSets(ll1Grammar), bnfAnalyzer.GetFollowSets(ll1Grammar, bnfAnalyzer.GetFirstSets(ll1Grammar)));

            Assert.AreEqual(true, isLL1);
        }

        


    }
}
