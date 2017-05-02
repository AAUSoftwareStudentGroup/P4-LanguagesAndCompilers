using Generator.Translation.Data;
using System;
using System.Collections.Generic;

namespace Generator.Translation.Parsing
{
	public class TranslatorParser 
	{
		public Generator.Translation.Data.Token ParseTerminal(IEnumerator<Generator.Translation.Data.Token> tokens, string expected)
		{
			if(expected == "EPSILON")
			{
			    return new Generator.Translation.Data.Token() { Name = "EPSILON" };
			}
			Generator.Translation.Data.Token token = tokens.Current;
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

		public Generator.Translation.Data.Translator ParseTranslator(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Translator node = new Generator.Translation.Data.Translator(){ Name = "Translator" };
			switch(tokens.Current.Name)
			{
			    case "goto":
			    case "<=>":
			    case "</>":
			    case "[":
			    case "symbol":
			    case "escapedSymbol":
			    case "newline":
			    case "eof":
			        node.Add(ParseSystems(tokens));
			        node.Add(ParseRules(tokens));
			        node.Add(ParseTerminal(tokens, "eof"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Systems ParseSystems(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Systems node = new Generator.Translation.Data.Systems(){ Name = "Systems" };
			switch(tokens.Current.Name)
			{
			    case "goto":
			    case "<=>":
			    case "</>":
			        node.Add(ParseSystem(tokens));
			        node.Add(ParseTerminal(tokens, "newline"));
			        node.Add(ParseSystems(tokens));
			        return node;
			    case "[":
			    case "symbol":
			    case "escapedSymbol":
			    case "newline":
			    case "eof":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.System ParseSystem(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.System node = new Generator.Translation.Data.System(){ Name = "System" };
			switch(tokens.Current.Name)
			{
			    case "goto":
			        node.Add(ParseTerminal(tokens, "goto"));
			        node.Add(ParseAlias(tokens));
			        node.Add(ParseTerminal(tokens, ":="));
			        node.Add(ParseDomain(tokens));
			        node.Add(ParseTerminal(tokens, "goto"));
			        node.Add(ParseDomain(tokens));
			        return node;
			    case "<=>":
			        node.Add(ParseTerminal(tokens, "<=>"));
			        node.Add(ParseAlias(tokens));
			        node.Add(ParseTerminal(tokens, ":="));
			        node.Add(ParseDomain(tokens));
			        node.Add(ParseTerminal(tokens, "<=>"));
			        node.Add(ParseDomain(tokens));
			        return node;
			    case "</>":
			        node.Add(ParseTerminal(tokens, "</>"));
			        node.Add(ParseAlias(tokens));
			        node.Add(ParseTerminal(tokens, ":="));
			        node.Add(ParseDomain(tokens));
			        node.Add(ParseTerminal(tokens, "</>"));
			        node.Add(ParseDomain(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Domain ParseDomain(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Domain node = new Generator.Translation.Data.Domain(){ Name = "Domain" };
			switch(tokens.Current.Name)
			{
			    case "[":
			        node.Add(ParseListDomain(tokens));
			        return node;
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseTreeDomain(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.ListDomain ParseListDomain(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.ListDomain node = new Generator.Translation.Data.ListDomain(){ Name = "ListDomain" };
			switch(tokens.Current.Name)
			{
			    case "[":
			        node.Add(ParseTerminal(tokens, "["));
			        node.Add(ParseDomains(tokens));
			        node.Add(ParseTerminal(tokens, "]"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Domains ParseDomains(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Domains node = new Generator.Translation.Data.Domains(){ Name = "Domains" };
			switch(tokens.Current.Name)
			{
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseTreeDomain(tokens));
			        node.Add(ParseDomains(tokens));
			        return node;
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.TreeDomain ParseTreeDomain(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.TreeDomain node = new Generator.Translation.Data.TreeDomain(){ Name = "TreeDomain" };
			switch(tokens.Current.Name)
			{
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseSymbol(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Symbol ParseSymbol(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Symbol node = new Generator.Translation.Data.Symbol(){ Name = "Symbol" };
			switch(tokens.Current.Name)
			{
			    case "symbol":
			        node.Add(ParseTerminal(tokens, "symbol"));
			        return node;
			    case "escapedSymbol":
			        node.Add(ParseTerminal(tokens, "escapedSymbol"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Rules ParseRules(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Rules node = new Generator.Translation.Data.Rules(){ Name = "Rules" };
			switch(tokens.Current.Name)
			{
			    case "[":
			    case "symbol":
			    case "escapedSymbol":
			    case "newline":
			    case "eof":
			        node.Add(ParseRule(tokens));
			        node.Add(ParseRulesP(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.RulesP ParseRulesP(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.RulesP node = new Generator.Translation.Data.RulesP(){ Name = "RulesP" };
			switch(tokens.Current.Name)
			{
			    case "newline":
			        node.Add(ParseTerminal(tokens, "newline"));
			        node.Add(ParseRule(tokens));
			        node.Add(ParseRulesP(tokens));
			        return node;
			    case "eof":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Rule ParseRule(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Rule node = new Generator.Translation.Data.Rule(){ Name = "Rule" };
			switch(tokens.Current.Name)
			{
			    case "[":
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseConclusion(tokens));
			        node.Add(ParsePremises(tokens));
			        return node;
			    case "newline":
			    case "eof":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Conclusion ParseConclusion(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Conclusion node = new Generator.Translation.Data.Conclusion(){ Name = "Conclusion" };
			switch(tokens.Current.Name)
			{
			    case "[":
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParsePattern(tokens));
			        node.Add(ParseNewlineGoto(tokens));
			        node.Add(ParseAlias(tokens));
			        node.Add(ParseStructure(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.NewlineGoto ParseNewlineGoto(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.NewlineGoto node = new Generator.Translation.Data.NewlineGoto(){ Name = "NewlineGoto" };
			switch(tokens.Current.Name)
			{
			    case "newline":
			        node.Add(ParseTerminal(tokens, "newline"));
			        node.Add(ParseTerminal(tokens, "goto"));
			        return node;
			    case "goto":
			        node.Add(ParseTerminal(tokens, "goto"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Premises ParsePremises(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Premises node = new Generator.Translation.Data.Premises(){ Name = "Premises" };
			switch(tokens.Current.Name)
			{
			    case "indent":
			        node.Add(ParseTerminal(tokens, "indent"));
			        node.Add(ParsePremis(tokens));
			        node.Add(ParsePremisesP(tokens));
			        node.Add(ParseTerminal(tokens, "dedent"));
			        return node;
			    case "newline":
			    case "eof":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.PremisesP ParsePremisesP(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.PremisesP node = new Generator.Translation.Data.PremisesP(){ Name = "PremisesP" };
			switch(tokens.Current.Name)
			{
			    case "newline":
			        node.Add(ParseTerminal(tokens, "newline"));
			        node.Add(ParsePremis(tokens));
			        node.Add(ParsePremisesP(tokens));
			        return node;
			    case "dedent":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Premis ParsePremis(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Premis node = new Generator.Translation.Data.Premis(){ Name = "Premis" };
			switch(tokens.Current.Name)
			{
			    case "[":
			    case "%":
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseStructure(tokens));
			        node.Add(ParseStructureOperation(tokens));
			        return node;
			    case "newline":
			    case "dedent":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.StructureOperation ParseStructureOperation(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.StructureOperation node = new Generator.Translation.Data.StructureOperation(){ Name = "StructureOperation" };
			switch(tokens.Current.Name)
			{
			    case "goto":
			        node.Add(ParseGoto(tokens));
			        return node;
			    case "<=>":
			        node.Add(ParseEqual(tokens));
			        return node;
			    case "</>":
			        node.Add(ParseNotEqual(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Goto ParseGoto(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Goto node = new Generator.Translation.Data.Goto(){ Name = "Goto" };
			switch(tokens.Current.Name)
			{
			    case "goto":
			        node.Add(ParseTerminal(tokens, "goto"));
			        node.Add(ParseAlias(tokens));
			        node.Add(ParsePattern(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Equal ParseEqual(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Equal node = new Generator.Translation.Data.Equal(){ Name = "Equal" };
			switch(tokens.Current.Name)
			{
			    case "<=>":
			        node.Add(ParseTerminal(tokens, "<=>"));
			        node.Add(ParseAlias(tokens));
			        node.Add(ParseStructure(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.NotEqual ParseNotEqual(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.NotEqual node = new Generator.Translation.Data.NotEqual(){ Name = "NotEqual" };
			switch(tokens.Current.Name)
			{
			    case "</>":
			        node.Add(ParseTerminal(tokens, "</>"));
			        node.Add(ParseAlias(tokens));
			        node.Add(ParseStructure(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Pattern ParsePattern(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Pattern node = new Generator.Translation.Data.Pattern(){ Name = "Pattern" };
			switch(tokens.Current.Name)
			{
			    case "[":
			        node.Add(ParseListPattern(tokens));
			        return node;
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseTreePattern(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.ListPattern ParseListPattern(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.ListPattern node = new Generator.Translation.Data.ListPattern(){ Name = "ListPattern" };
			switch(tokens.Current.Name)
			{
			    case "[":
			        node.Add(ParseTerminal(tokens, "["));
			        node.Add(ParsePatterns(tokens));
			        node.Add(ParseTerminal(tokens, "]"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.TreePattern ParseTreePattern(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.TreePattern node = new Generator.Translation.Data.TreePattern(){ Name = "TreePattern" };
			switch(tokens.Current.Name)
			{
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseName(tokens));
			        node.Add(ParseAlias(tokens));
			        node.Add(ParseChildrenPattern(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Name ParseName(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Name node = new Generator.Translation.Data.Name(){ Name = "Name" };
			switch(tokens.Current.Name)
			{
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseSymbol(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Alias ParseAlias(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Alias node = new Generator.Translation.Data.Alias(){ Name = "Alias" };
			switch(tokens.Current.Name)
			{
			    case ":":
			        node.Add(ParseTerminal(tokens, ":"));
			        node.Add(ParseTerminal(tokens, "symbol"));
			        return node;
			    case ":=":
			    case "[":
			    case "%":
			    case "symbol":
			    case "escapedSymbol":
			    case "newline":
			    case "goto":
			    case "dedent":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.ChildrenPattern ParseChildrenPattern(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.ChildrenPattern node = new Generator.Translation.Data.ChildrenPattern(){ Name = "ChildrenPattern" };
			switch(tokens.Current.Name)
			{
			    case "[":
			        node.Add(ParseTerminal(tokens, "["));
			        node.Add(ParsePatterns(tokens));
			        node.Add(ParseTerminal(tokens, "]"));
			        return node;
			    case "newline":
			    case "goto":
			    case "dedent":
			    case "symbol":
			    case "escapedSymbol":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Patterns ParsePatterns(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Patterns node = new Generator.Translation.Data.Patterns(){ Name = "Patterns" };
			switch(tokens.Current.Name)
			{
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseTreePattern(tokens));
			        node.Add(ParsePatterns(tokens));
			        return node;
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Structure ParseStructure(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Structure node = new Generator.Translation.Data.Structure(){ Name = "Structure" };
			switch(tokens.Current.Name)
			{
			    case "[":
			        node.Add(ParseListStructure(tokens));
			        return node;
			    case "%":
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseTreeStructure(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.ListStructure ParseListStructure(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.ListStructure node = new Generator.Translation.Data.ListStructure(){ Name = "ListStructure" };
			switch(tokens.Current.Name)
			{
			    case "[":
			        node.Add(ParseTerminal(tokens, "["));
			        node.Add(ParseStructures(tokens));
			        node.Add(ParseTerminal(tokens, "]"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.TreeStructure ParseTreeStructure(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.TreeStructure node = new Generator.Translation.Data.TreeStructure(){ Name = "TreeStructure" };
			switch(tokens.Current.Name)
			{
			    case "%":
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParsePlaceholder(tokens));
			        node.Add(ParseName(tokens));
			        node.Add(ParseChildrenStructure(tokens));
			        node.Add(ParseInsertion(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Placeholder ParsePlaceholder(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Placeholder node = new Generator.Translation.Data.Placeholder(){ Name = "Placeholder" };
			switch(tokens.Current.Name)
			{
			    case "%":
			        node.Add(ParseTerminal(tokens, "%"));
			        return node;
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Insertion ParseInsertion(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Insertion node = new Generator.Translation.Data.Insertion(){ Name = "Insertion" };
			switch(tokens.Current.Name)
			{
			    case "insert":
			        node.Add(ParseTerminal(tokens, "insert"));
			        node.Add(ParseTreeStructure(tokens));
			        return node;
			    case "indent":
			    case "newline":
			    case "eof":
			    case "goto":
			    case "<=>":
			    case "</>":
			    case "dedent":
			    case "%":
			    case "symbol":
			    case "escapedSymbol":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.ChildrenStructure ParseChildrenStructure(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.ChildrenStructure node = new Generator.Translation.Data.ChildrenStructure(){ Name = "ChildrenStructure" };
			switch(tokens.Current.Name)
			{
			    case "[":
			        node.Add(ParseTerminal(tokens, "["));
			        node.Add(ParseStructures(tokens));
			        node.Add(ParseTerminal(tokens, "]"));
			        return node;
			    case "insert":
			    case "indent":
			    case "newline":
			    case "eof":
			    case "goto":
			    case "<=>":
			    case "</>":
			    case "dedent":
			    case "%":
			    case "symbol":
			    case "escapedSymbol":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Generator.Translation.Data.Structures ParseStructures(IEnumerator<Generator.Translation.Data.Token> tokens)
		{
			Generator.Translation.Data.Structures node = new Generator.Translation.Data.Structures(){ Name = "Structures" };
			switch(tokens.Current.Name)
			{
			    case "%":
			    case "symbol":
			    case "escapedSymbol":
			        node.Add(ParseTreeStructure(tokens));
			        node.Add(ParseStructures(tokens));
			        return node;
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}
	}
}
