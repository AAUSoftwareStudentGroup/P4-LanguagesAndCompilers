using Compiler.Data;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System;

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

		/* S -> f S Y
		 * | EPSILON
		 * Y -> f g S 
		 * | y */
		Bnf TestLL2Bnf()
		{
			Symbol f = TestSymbol("f");
			Symbol g = TestSymbol("g");
			Symbol y = TestSymbol("y");
			Symbol e = TestSymbol("EPSILON");

			Production Y = TestProduction("Y", TestExpansion(f, g), TestExpansion(y));
			Production S = TestProduction("S", TestExpansion(f), TestExpansion(e));
			// add non-terminals S, Y to S
			S.Expansions[0].Symbols.Add(S);
			S.Expansions[0].Symbols.Add(Y);
			// add non-terminal S to Y
			Y.Expansions[0].Symbols.Add(S);
			List<Production> productions = new List<Production>() { Y, S };

			return new Bnf(S, productions, new List<Symbol>() { f, g, y, e }); ;
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

			Bnf bnf2 = TestLL1Bnf2();
			string bnf2Error;
			Assert.True(bnf2.IsLL1(out bnf2Error));

			// based on the ll(2) grammar; expect false because of failure to comply with condition 2
			Bnf bnf3 = TestLL2Bnf();
			string bnf3Error;
			Assert.False(bnf3.IsLL1(out bnf3Error));
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

			//New test with new bnf
			Bnf bnf2 = TestLL1Bnf2();
			Production S2 = bnf2.Productions.FirstOrDefault(p => p.Name == "S");
			Symbol b2 = bnf2.Terminals.FirstOrDefault(s => s.Name == "b");

			List<Symbol> expected2 = new List<Symbol>() { b2 };

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
