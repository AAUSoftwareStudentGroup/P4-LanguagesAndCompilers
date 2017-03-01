using Compiler.Data;
using Compiler.Parsing.BnfParsing;
using System.Collections.Generic;
using System;
using Xunit;
using System.Linq;

namespace Compiler.Tests
{
    public class BnfTests
    {
        Symbol TestSymbol(string name) => new Symbol()
        {
            Name = name
        };

        Expansion TestExpansion(params Symbol[] symbols) => new Expansion()
        {
            Symbols = symbols.ToList()
        };

        Production TestProduction(string productionName, params Expansion[] expansions) => new Production()
        {
            Name = productionName,
            Expansions = expansions.ToList()
        };

        Bnf TestLL1Bnf()
        {
            Symbol a = TestSymbol("a");
            Symbol b = TestSymbol("b");
            Symbol d = TestSymbol("d");
            Symbol e = TestSymbol("EPSILON");
            
            Production D = TestProduction("D", TestExpansion(d),
                                               TestExpansion(e));
            Production B = TestProduction("B", TestExpansion(b),
                                               TestExpansion(e));
            Production A = TestProduction("A", TestExpansion(B, D));
            Production S = TestProduction("S", TestExpansion(A, a));

            List<Production> productions = new List<Production>() { D, B, A, S };

            return new Bnf(S, productions, new List<Symbol>() { a, b, d, e });
        }

        Bnf TestLL1Bnf2()
        {
            Symbol a = TestSymbol("a");
            Symbol b = TestSymbol("b");
            Symbol d = TestSymbol("d");
            Symbol e = TestSymbol("EPSILON");

            Production D = TestProduction("D", TestExpansion(d),
                                               TestExpansion(e));
            Production B = TestProduction("B", TestExpansion(b));
            Production A = TestProduction("A", TestExpansion(B, D));
            Production S = TestProduction("S", TestExpansion(A, a));

            List<Production> productions = new List<Production>() { D, B, A, S };

            return new Bnf(S, productions, new List<Symbol>() { a, b, d, e });
        }

        [Fact]
        public void Constructor()
        {
            Bnf bnf = TestLL1Bnf();

            Assert.NotNull(bnf);
        }

        [Fact]
        public void IsLL1()
        {
            Bnf bnf = TestLL1Bnf();

            string error;
            Assert.True(bnf.IsLL1(out error));
        }

        [Fact]
        public void FirstSet()
        {
            Bnf bnf = TestLL1Bnf();
            Production S = bnf.Productions.FirstOrDefault(p => p.Name == "S");
            Symbol a = bnf.Terminals.FirstOrDefault(s => s.Name == "a");
            Symbol b = bnf.Terminals.FirstOrDefault(s => s.Name == "b");
            Symbol d = bnf.Terminals.FirstOrDefault(s => s.Name == "d");
            List<Symbol> expected = new List<Symbol>() { a, b, d };

            foreach (var item in S.FirstSet())
            {
                System.Diagnostics.Debug.WriteLine("expected" + " " + item);
            }

            Assert.Equal(expected.Count, S.FirstSet().Intersect(expected).Count());
        }

        [Fact]
        public void FirstSet2()
        {
            Bnf bnf2 = TestLL1Bnf2();
            Production S2 = bnf2.Productions.FirstOrDefault(p => p.Name == "S");
            Symbol b = bnf2.Terminals.FirstOrDefault(s => s.Name == "b");

            List<Symbol> expected2 = new List<Symbol>() { b };

            Assert.Equal(expected2.Count, S2.FirstSet().Intersect(expected2).Count());
        }

        [Fact]
        public void FollowSet()
        {
            Bnf bnf = TestLL1Bnf();
            Production D = bnf.Productions.FirstOrDefault(p => p.Name == "D");
            Symbol a = bnf.Terminals.FirstOrDefault(s => s.Name == "a");
            List<Symbol> expected = new List<Symbol>() { a };
            Assert.Equal(expected.Count, D.FollowSet(bnf).Intersect(expected).Count());
        }
    }
}
