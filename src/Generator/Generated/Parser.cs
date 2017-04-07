using System;
using System.Collections.Generic;

namespace Generator.Generated
{
	public class Parser 
	{
		public Token ParseTerminal(IEnumerator<Token> tokens, string expected)
		{
			Token token = tokens.Current;
			if(token.Name == expected)
			{
				tokens.MoveNext();
				return token;
			}
			else
			{
				throw new Exception();
			}
		}

		public S ParseS(IEnumerator<Token> tokens)
		{
			S node = new S(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "b":
				case "d":
				case "a":
					node.Children.Add(ParseA(tokens));
					node.Children.Add(ParseTerminal(tokens, "a"));
					return node;
				default:
					throw new Exception();
			}
		}

		public A ParseA(IEnumerator<Token> tokens)
		{
			A node = new A(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "b":
				case "d":
				case "a":
					node.Children.Add(ParseB(tokens));
					node.Children.Add(ParseD(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public B ParseB(IEnumerator<Token> tokens)
		{
			B node = new B(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "b":
					node.Children.Add(ParseTerminal(tokens, "b"));
					return node;
				case "d":
				case "a":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public D ParseD(IEnumerator<Token> tokens)
		{
			D node = new D(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "d":
					node.Children.Add(ParseTerminal(tokens, "d"));
					return node;
				case "a":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}
	}
}
