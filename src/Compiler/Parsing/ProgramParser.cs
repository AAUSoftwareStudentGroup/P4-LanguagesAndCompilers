using Compiler.Parsing.Data;
using System;
using System.Collections.Generic;

namespace Compiler.Parsing
{
	public class ProgramParser 
	{
		public Compiler.Parsing.Data.Token ParseTerminal(IEnumerator<Compiler.Parsing.Data.Token> tokens, string expected)
		{
			if(expected == "EPSILON")
			{
			    return new Compiler.Parsing.Data.Token() { Name = "EPSILON" };
			}
			Compiler.Parsing.Data.Token token = tokens.Current;
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

		public Compiler.Parsing.Data.Program ParseProgram(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.Program node = new Compiler.Parsing.Data.Program(){ Name = "Program" };
			switch(tokens.Current.Name)
			{
			    case "interrupt":
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			    case "bool":
			    case "nothing":
			    case "identifier":
			    case "register8":
			    case "register16":
			    case "if":
			    case "while":
			    case "for":
			    case "return":
			    case "newline":
			    case "eof":
			        node.Add(ParseGlobalStatements(tokens));
			        node.Add(ParseTerminal(tokens, "eof"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.GlobalStatements ParseGlobalStatements(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.GlobalStatements node = new Compiler.Parsing.Data.GlobalStatements(){ Name = "GlobalStatements" };
			switch(tokens.Current.Name)
			{
			    case "interrupt":
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			    case "bool":
			    case "nothing":
			    case "identifier":
			    case "register8":
			    case "register16":
			    case "if":
			    case "while":
			    case "for":
			    case "return":
			    case "newline":
			        node.Add(ParseGlobalStatement(tokens));
			        node.Add(ParseGlobalStatements(tokens));
			        return node;
			    case "eof":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.GlobalStatement ParseGlobalStatement(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.GlobalStatement node = new Compiler.Parsing.Data.GlobalStatement(){ Name = "GlobalStatement" };
			switch(tokens.Current.Name)
			{
			    case "interrupt":
			        node.Add(ParseInterrupt(tokens));
			        return node;
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			    case "bool":
			    case "nothing":
			    case "identifier":
			    case "register8":
			    case "register16":
			    case "if":
			    case "while":
			    case "for":
			    case "return":
			    case "newline":
			        node.Add(ParseStatement(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.Interrupt ParseInterrupt(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.Interrupt node = new Compiler.Parsing.Data.Interrupt(){ Name = "Interrupt" };
			switch(tokens.Current.Name)
			{
			    case "interrupt":
			        node.Add(ParseTerminal(tokens, "interrupt"));
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseTerminal(tokens, "numeral"));
			        node.Add(ParseTerminal(tokens, ")"));
			        node.Add(ParseTerminal(tokens, "indent"));
			        node.Add(ParseStatements(tokens));
			        node.Add(ParseTerminal(tokens, "dedent"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.Statements ParseStatements(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.Statements node = new Compiler.Parsing.Data.Statements(){ Name = "Statements" };
			switch(tokens.Current.Name)
			{
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			    case "bool":
			    case "nothing":
			    case "identifier":
			    case "register8":
			    case "register16":
			    case "if":
			    case "while":
			    case "for":
			    case "return":
			    case "newline":
			        node.Add(ParseStatement(tokens));
			        node.Add(ParseStatements(tokens));
			        return node;
			    case "dedent":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.Statement ParseStatement(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.Statement node = new Compiler.Parsing.Data.Statement(){ Name = "Statement" };
			switch(tokens.Current.Name)
			{
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			    case "bool":
			    case "nothing":
			        node.Add(ParseIdentifierDeclaration(tokens));
			        return node;
			    case "identifier":
			        node.Add(ParseIdentifierStatement(tokens));
			        return node;
			    case "register8":
			    case "register16":
			        node.Add(ParseRegisterStatement(tokens));
			        return node;
			    case "if":
			        node.Add(ParseIfStatement(tokens));
			        return node;
			    case "while":
			        node.Add(ParseWhileStatement(tokens));
			        return node;
			    case "for":
			        node.Add(ParseForStatement(tokens));
			        return node;
			    case "return":
			        node.Add(ParseReturnStatement(tokens));
			        return node;
			    case "newline":
			        node.Add(ParseTerminal(tokens, "newline"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.IdentifierDeclaration ParseIdentifierDeclaration(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.IdentifierDeclaration node = new Compiler.Parsing.Data.IdentifierDeclaration(){ Name = "IdentifierDeclaration" };
			switch(tokens.Current.Name)
			{
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			        node.Add(ParseIntType(tokens));
			        node.Add(ParseTerminal(tokens, "identifier"));
			        node.Add(ParseDefinition(tokens));
			        return node;
			    case "bool":
			        node.Add(ParseBooleanType(tokens));
			        node.Add(ParseTerminal(tokens, "identifier"));
			        node.Add(ParseDefinition(tokens));
			        return node;
			    case "nothing":
			        node.Add(ParseTerminal(tokens, "nothing"));
			        node.Add(ParseTerminal(tokens, "identifier"));
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseFormalParameters(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        node.Add(ParseTerminal(tokens, "indent"));
			        node.Add(ParseStatements(tokens));
			        node.Add(ParseTerminal(tokens, "dedent"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.RegisterStatement ParseRegisterStatement(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.RegisterStatement node = new Compiler.Parsing.Data.RegisterStatement(){ Name = "RegisterStatement" };
			switch(tokens.Current.Name)
			{
			    case "register8":
			    case "register16":
			        node.Add(ParseRegisterType(tokens));
			        node.Add(ParseRegisterOperation(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.RegisterType ParseRegisterType(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.RegisterType node = new Compiler.Parsing.Data.RegisterType(){ Name = "RegisterType" };
			switch(tokens.Current.Name)
			{
			    case "register8":
			        node.Add(ParseTerminal(tokens, "register8"));
			        return node;
			    case "register16":
			        node.Add(ParseTerminal(tokens, "register16"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.RegisterOperation ParseRegisterOperation(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.RegisterOperation node = new Compiler.Parsing.Data.RegisterOperation(){ Name = "RegisterOperation" };
			switch(tokens.Current.Name)
			{
			    case "(":
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        node.Add(ParseTerminal(tokens, "{"));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, "}"));
			        node.Add(ParseTerminal(tokens, "="));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, "newline"));
			        return node;
			    case "identifier":
			        node.Add(ParseTerminal(tokens, "identifier"));
			        node.Add(ParseDefinition(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.Definition ParseDefinition(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.Definition node = new Compiler.Parsing.Data.Definition(){ Name = "Definition" };
			switch(tokens.Current.Name)
			{
			    case "=":
			        node.Add(ParseTerminal(tokens, "="));
			        node.Add(ParseDefinitionAssign(tokens));
			        return node;
			    case "(":
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseFormalParameters(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        node.Add(ParseTerminal(tokens, "indent"));
			        node.Add(ParseStatements(tokens));
			        node.Add(ParseTerminal(tokens, "dedent"));
			        return node;
			    case "newline":
			        node.Add(ParseTerminal(tokens, "newline"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.DefinitionAssign ParseDefinitionAssign(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.DefinitionAssign node = new Compiler.Parsing.Data.DefinitionAssign(){ Name = "DefinitionAssign" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, "newline"));
			        return node;
			    case "[":
			        node.Add(ParseTerminal(tokens, "["));
			        node.Add(ParseExpressionList(tokens));
			        node.Add(ParseTerminal(tokens, "]"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.ReturnStatement ParseReturnStatement(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.ReturnStatement node = new Compiler.Parsing.Data.ReturnStatement(){ Name = "ReturnStatement" };
			switch(tokens.Current.Name)
			{
			    case "return":
			        node.Add(ParseTerminal(tokens, "return"));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, "newline"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.FormalParameters ParseFormalParameters(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.FormalParameters node = new Compiler.Parsing.Data.FormalParameters(){ Name = "FormalParameters" };
			switch(tokens.Current.Name)
			{
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			    case "register8":
			    case "register16":
			    case "bool":
			        node.Add(ParseFormalParameter(tokens));
			        node.Add(ParseFormalParametersP(tokens));
			        return node;
			    case ")":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.FormalParametersP ParseFormalParametersP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.FormalParametersP node = new Compiler.Parsing.Data.FormalParametersP(){ Name = "FormalParametersP" };
			switch(tokens.Current.Name)
			{
			    case ",":
			        node.Add(ParseTerminal(tokens, ","));
			        node.Add(ParseFormalParameter(tokens));
			        node.Add(ParseFormalParametersP(tokens));
			        return node;
			    case ")":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.FormalParameter ParseFormalParameter(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.FormalParameter node = new Compiler.Parsing.Data.FormalParameter(){ Name = "FormalParameter" };
			switch(tokens.Current.Name)
			{
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			    case "register8":
			    case "register16":
			    case "bool":
			        node.Add(ParseType(tokens));
			        node.Add(ParseTerminal(tokens, "identifier"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.Type ParseType(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.Type node = new Compiler.Parsing.Data.Type(){ Name = "Type" };
			switch(tokens.Current.Name)
			{
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			        node.Add(ParseIntType(tokens));
			        return node;
			    case "register8":
			    case "register16":
			        node.Add(ParseRegisterType(tokens));
			        return node;
			    case "bool":
			        node.Add(ParseBooleanType(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.IdentifierStatement ParseIdentifierStatement(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.IdentifierStatement node = new Compiler.Parsing.Data.IdentifierStatement(){ Name = "IdentifierStatement" };
			switch(tokens.Current.Name)
			{
			    case "identifier":
			        node.Add(ParseTerminal(tokens, "identifier"));
			        node.Add(ParseIdentifierStatementP(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.IdentifierStatementP ParseIdentifierStatementP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.IdentifierStatementP node = new Compiler.Parsing.Data.IdentifierStatementP(){ Name = "IdentifierStatementP" };
			switch(tokens.Current.Name)
			{
			    case "{":
			    case "=":
			        node.Add(ParseBitSelector(tokens));
			        node.Add(ParseTerminal(tokens, "="));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, "newline"));
			        return node;
			    case "(":
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseExpressionList(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.BitSelector ParseBitSelector(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.BitSelector node = new Compiler.Parsing.Data.BitSelector(){ Name = "BitSelector" };
			switch(tokens.Current.Name)
			{
			    case "{":
			        node.Add(ParseTerminal(tokens, "{"));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, "}"));
			        return node;
			    case "=":
			    case "^":
			    case "/":
			    case "*":
			    case "%":
			    case "+":
			    case "-":
			    case "<":
			    case ">":
			    case "<=":
			    case ">=":
			    case "==":
			    case "!=":
			    case "and":
			    case "or":
			    case ")":
			    case "}":
			    case "newline":
			    case "to":
			    case ",":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.IfStatement ParseIfStatement(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.IfStatement node = new Compiler.Parsing.Data.IfStatement(){ Name = "IfStatement" };
			switch(tokens.Current.Name)
			{
			    case "if":
			        node.Add(ParseTerminal(tokens, "if"));
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        node.Add(ParseTerminal(tokens, "indent"));
			        node.Add(ParseStatements(tokens));
			        node.Add(ParseTerminal(tokens, "dedent"));
			        node.Add(ParseElseStatement(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.ElseStatement ParseElseStatement(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.ElseStatement node = new Compiler.Parsing.Data.ElseStatement(){ Name = "ElseStatement" };
			switch(tokens.Current.Name)
			{
			    case "else":
			        node.Add(ParseTerminal(tokens, "else"));
			        node.Add(ParseTerminal(tokens, "indent"));
			        node.Add(ParseStatements(tokens));
			        node.Add(ParseTerminal(tokens, "dedent"));
			        return node;
			    case "interrupt":
			    case "int8":
			    case "int16":
			    case "int32":
			    case "uint8":
			    case "uint16":
			    case "uint32":
			    case "bool":
			    case "nothing":
			    case "identifier":
			    case "register8":
			    case "register16":
			    case "if":
			    case "while":
			    case "for":
			    case "return":
			    case "newline":
			    case "eof":
			    case "dedent":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.WhileStatement ParseWhileStatement(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.WhileStatement node = new Compiler.Parsing.Data.WhileStatement(){ Name = "WhileStatement" };
			switch(tokens.Current.Name)
			{
			    case "while":
			        node.Add(ParseTerminal(tokens, "while"));
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        node.Add(ParseTerminal(tokens, "indent"));
			        node.Add(ParseStatements(tokens));
			        node.Add(ParseTerminal(tokens, "dedent"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.ForStatement ParseForStatement(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.ForStatement node = new Compiler.Parsing.Data.ForStatement(){ Name = "ForStatement" };
			switch(tokens.Current.Name)
			{
			    case "for":
			        node.Add(ParseTerminal(tokens, "for"));
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseIntType(tokens));
			        node.Add(ParseTerminal(tokens, "identifier"));
			        node.Add(ParseTerminal(tokens, "from"));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, "to"));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        node.Add(ParseTerminal(tokens, "indent"));
			        node.Add(ParseStatements(tokens));
			        node.Add(ParseTerminal(tokens, "dedent"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.IntType ParseIntType(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.IntType node = new Compiler.Parsing.Data.IntType(){ Name = "IntType" };
			switch(tokens.Current.Name)
			{
			    case "int8":
			        node.Add(ParseTerminal(tokens, "int8"));
			        return node;
			    case "int16":
			        node.Add(ParseTerminal(tokens, "int16"));
			        return node;
			    case "int32":
			        node.Add(ParseTerminal(tokens, "int32"));
			        return node;
			    case "uint8":
			        node.Add(ParseTerminal(tokens, "uint8"));
			        return node;
			    case "uint16":
			        node.Add(ParseTerminal(tokens, "uint16"));
			        return node;
			    case "uint32":
			        node.Add(ParseTerminal(tokens, "uint32"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.BooleanType ParseBooleanType(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.BooleanType node = new Compiler.Parsing.Data.BooleanType(){ Name = "BooleanType" };
			switch(tokens.Current.Name)
			{
			    case "bool":
			        node.Add(ParseTerminal(tokens, "bool"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.Expression ParseExpression(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.Expression node = new Compiler.Parsing.Data.Expression(){ Name = "Expression" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParseOrExpression(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.OrExpression ParseOrExpression(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.OrExpression node = new Compiler.Parsing.Data.OrExpression(){ Name = "OrExpression" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParseAndExpression(tokens));
			        node.Add(ParseOrExpressionP(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.OrExpressionP ParseOrExpressionP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.OrExpressionP node = new Compiler.Parsing.Data.OrExpressionP(){ Name = "OrExpressionP" };
			switch(tokens.Current.Name)
			{
			    case "or":
			        node.Add(ParseTerminal(tokens, "or"));
			        node.Add(ParseAndExpression(tokens));
			        node.Add(ParseOrExpressionP(tokens));
			        return node;
			    case ")":
			    case "}":
			    case "newline":
			    case "to":
			    case ",":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.AndExpression ParseAndExpression(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.AndExpression node = new Compiler.Parsing.Data.AndExpression(){ Name = "AndExpression" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParseEqExpression(tokens));
			        node.Add(ParseAndExpressionP(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.AndExpressionP ParseAndExpressionP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.AndExpressionP node = new Compiler.Parsing.Data.AndExpressionP(){ Name = "AndExpressionP" };
			switch(tokens.Current.Name)
			{
			    case "and":
			        node.Add(ParseTerminal(tokens, "and"));
			        node.Add(ParseEqExpression(tokens));
			        node.Add(ParseAndExpressionP(tokens));
			        return node;
			    case "or":
			    case ")":
			    case "}":
			    case "newline":
			    case "to":
			    case ",":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.EqExpression ParseEqExpression(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.EqExpression node = new Compiler.Parsing.Data.EqExpression(){ Name = "EqExpression" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParseRelationalExpression(tokens));
			        node.Add(ParseEqExpressionP(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.EqExpressionP ParseEqExpressionP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.EqExpressionP node = new Compiler.Parsing.Data.EqExpressionP(){ Name = "EqExpressionP" };
			switch(tokens.Current.Name)
			{
			    case "==":
			        node.Add(ParseTerminal(tokens, "=="));
			        node.Add(ParseRelationalExpression(tokens));
			        node.Add(ParseEqExpressionP(tokens));
			        return node;
			    case "!=":
			        node.Add(ParseTerminal(tokens, "!="));
			        node.Add(ParseRelationalExpression(tokens));
			        node.Add(ParseEqExpressionP(tokens));
			        return node;
			    case "and":
			    case "or":
			    case ")":
			    case "}":
			    case "newline":
			    case "to":
			    case ",":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.RelationalExpression ParseRelationalExpression(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.RelationalExpression node = new Compiler.Parsing.Data.RelationalExpression(){ Name = "RelationalExpression" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParseAddSubExpression(tokens));
			        node.Add(ParseRelationalExpressionP(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.RelationalExpressionP ParseRelationalExpressionP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.RelationalExpressionP node = new Compiler.Parsing.Data.RelationalExpressionP(){ Name = "RelationalExpressionP" };
			switch(tokens.Current.Name)
			{
			    case "<":
			        node.Add(ParseTerminal(tokens, "<"));
			        node.Add(ParseAddSubExpression(tokens));
			        node.Add(ParseRelationalExpressionP(tokens));
			        return node;
			    case ">":
			        node.Add(ParseTerminal(tokens, ">"));
			        node.Add(ParseAddSubExpression(tokens));
			        node.Add(ParseRelationalExpressionP(tokens));
			        return node;
			    case "<=":
			        node.Add(ParseTerminal(tokens, "<="));
			        node.Add(ParseAddSubExpression(tokens));
			        node.Add(ParseRelationalExpressionP(tokens));
			        return node;
			    case ">=":
			        node.Add(ParseTerminal(tokens, ">="));
			        node.Add(ParseAddSubExpression(tokens));
			        node.Add(ParseRelationalExpressionP(tokens));
			        return node;
			    case "==":
			    case "!=":
			    case "and":
			    case "or":
			    case ")":
			    case "}":
			    case "newline":
			    case "to":
			    case ",":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.AddSubExpression ParseAddSubExpression(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.AddSubExpression node = new Compiler.Parsing.Data.AddSubExpression(){ Name = "AddSubExpression" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParseMulDivExpression(tokens));
			        node.Add(ParseAddSubExpressionP(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.AddSubExpressionP ParseAddSubExpressionP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.AddSubExpressionP node = new Compiler.Parsing.Data.AddSubExpressionP(){ Name = "AddSubExpressionP" };
			switch(tokens.Current.Name)
			{
			    case "+":
			        node.Add(ParseTerminal(tokens, "+"));
			        node.Add(ParseMulDivExpression(tokens));
			        node.Add(ParseAddSubExpressionP(tokens));
			        return node;
			    case "-":
			        node.Add(ParseTerminal(tokens, "-"));
			        node.Add(ParseMulDivExpression(tokens));
			        node.Add(ParseAddSubExpressionP(tokens));
			        return node;
			    case "<":
			    case ">":
			    case "<=":
			    case ">=":
			    case "==":
			    case "!=":
			    case "and":
			    case "or":
			    case ")":
			    case "}":
			    case "newline":
			    case "to":
			    case ",":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.MulDivExpression ParseMulDivExpression(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.MulDivExpression node = new Compiler.Parsing.Data.MulDivExpression(){ Name = "MulDivExpression" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParsePowExpression(tokens));
			        node.Add(ParseMulDivExpressionP(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.MulDivExpressionP ParseMulDivExpressionP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.MulDivExpressionP node = new Compiler.Parsing.Data.MulDivExpressionP(){ Name = "MulDivExpressionP" };
			switch(tokens.Current.Name)
			{
			    case "/":
			        node.Add(ParseTerminal(tokens, "/"));
			        node.Add(ParsePowExpression(tokens));
			        node.Add(ParseMulDivExpressionP(tokens));
			        return node;
			    case "*":
			        node.Add(ParseTerminal(tokens, "*"));
			        node.Add(ParsePowExpression(tokens));
			        node.Add(ParseMulDivExpressionP(tokens));
			        return node;
			    case "%":
			        node.Add(ParseTerminal(tokens, "%"));
			        node.Add(ParsePowExpression(tokens));
			        node.Add(ParseMulDivExpressionP(tokens));
			        return node;
			    case "+":
			    case "-":
			    case "<":
			    case ">":
			    case "<=":
			    case ">=":
			    case "==":
			    case "!=":
			    case "and":
			    case "or":
			    case ")":
			    case "}":
			    case "newline":
			    case "to":
			    case ",":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.PowExpression ParsePowExpression(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.PowExpression node = new Compiler.Parsing.Data.PowExpression(){ Name = "PowExpression" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParsePrimaryExpression(tokens));
			        node.Add(ParsePowExpressionP(tokens));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.PowExpressionP ParsePowExpressionP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.PowExpressionP node = new Compiler.Parsing.Data.PowExpressionP(){ Name = "PowExpressionP" };
			switch(tokens.Current.Name)
			{
			    case "^":
			        node.Add(ParseTerminal(tokens, "^"));
			        node.Add(ParsePrimaryExpression(tokens));
			        node.Add(ParsePowExpressionP(tokens));
			        return node;
			    case "/":
			    case "*":
			    case "%":
			    case "+":
			    case "-":
			    case "<":
			    case ">":
			    case "<=":
			    case ">=":
			    case "==":
			    case "!=":
			    case "and":
			    case "or":
			    case ")":
			    case "}":
			    case "newline":
			    case "to":
			    case ",":
			    case "]":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.PrimaryExpression ParsePrimaryExpression(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.PrimaryExpression node = new Compiler.Parsing.Data.PrimaryExpression(){ Name = "PrimaryExpression" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			        node.Add(ParseTerminal(tokens, "numeral"));
			        return node;
			    case "identifier":
			        node.Add(ParseTerminal(tokens, "identifier"));
			        node.Add(ParseIdentifierOperation(tokens));
			        return node;
			    case "(":
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        return node;
			    case "!":
			        node.Add(ParseTerminal(tokens, "!"));
			        node.Add(ParsePrimaryExpression(tokens));
			        return node;
			    case "register8":
			    case "register16":
			        node.Add(ParseRegisterType(tokens));
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        node.Add(ParseBitSelector(tokens));
			        return node;
			    case "true":
			        node.Add(ParseTerminal(tokens, "true"));
			        return node;
			    case "false":
			        node.Add(ParseTerminal(tokens, "false"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.IdentifierOperation ParseIdentifierOperation(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.IdentifierOperation node = new Compiler.Parsing.Data.IdentifierOperation(){ Name = "IdentifierOperation" };
			switch(tokens.Current.Name)
			{
			    case "{":
			    case "^":
			    case "/":
			    case "*":
			    case "%":
			    case "+":
			    case "-":
			    case "<":
			    case ">":
			    case "<=":
			    case ">=":
			    case "==":
			    case "!=":
			    case "and":
			    case "or":
			    case ")":
			    case "}":
			    case "newline":
			    case "to":
			    case ",":
			    case "]":
			        node.Add(ParseBitSelector(tokens));
			        return node;
			    case "(":
			        node.Add(ParseTerminal(tokens, "("));
			        node.Add(ParseExpressionList(tokens));
			        node.Add(ParseTerminal(tokens, ")"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.ExpressionList ParseExpressionList(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.ExpressionList node = new Compiler.Parsing.Data.ExpressionList(){ Name = "ExpressionList" };
			switch(tokens.Current.Name)
			{
			    case "numeral":
			    case "identifier":
			    case "(":
			    case "!":
			    case "register8":
			    case "register16":
			    case "true":
			    case "false":
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseExpressionListP(tokens));
			        return node;
			    case "]":
			    case ")":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}

		public Compiler.Parsing.Data.ExpressionListP ParseExpressionListP(IEnumerator<Compiler.Parsing.Data.Token> tokens)
		{
			Compiler.Parsing.Data.ExpressionListP node = new Compiler.Parsing.Data.ExpressionListP(){ Name = "ExpressionListP" };
			switch(tokens.Current.Name)
			{
			    case ",":
			        node.Add(ParseTerminal(tokens, ","));
			        node.Add(ParseExpression(tokens));
			        node.Add(ParseExpressionListP(tokens));
			        return node;
			    case "]":
			    case ")":
			        node.Add(ParseTerminal(tokens, "EPSILON"));
			        return node;
			    default:
			        throw new Exception();
			}
		}
	}
}
