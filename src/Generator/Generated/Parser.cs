using System;
using System.Collections.Generic;

namespace Generator.Generated
{
	public class Parser 
	{
		public Token ParseTerminal(IEnumerator<Token> tokens, string expected)
		{
			if(expected == "EPSILON")
			{
				return new Token() { Name = "EPSILON" };
			}
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

		public Program ParseProgram(IEnumerator<Token> tokens)
		{
			Program node = new Program(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
				case "identifier":
				case "if":
				case "while":
				case "for":
				case "interrupt":
				case "class":
				case "newline":
				case "eof":
					node.Children.Add(ParseStatements(tokens));
					node.Children.Add(ParseTerminal(tokens, "eof"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Statements ParseStatements(IEnumerator<Token> tokens)
		{
			Statements node = new Statements(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
				case "identifier":
				case "if":
				case "while":
				case "for":
				case "interrupt":
				case "class":
				case "newline":
				case "eof":
					node.Children.Add(ParseStatement(tokens));
					node.Children.Add(ParseStatementsP(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public StatementsP ParseStatementsP(IEnumerator<Token> tokens)
		{
			StatementsP node = new StatementsP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "newline":
					node.Children.Add(ParseTerminal(tokens, "newline"));
					node.Children.Add(ParseStatement(tokens));
					node.Children.Add(ParseStatementsP(tokens));
					return node;
				case "eof":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Statement ParseStatement(IEnumerator<Token> tokens)
		{
			Statement node = new Statement(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseDeclaration(tokens));
					return node;
				case "identifier":
					node.Children.Add(ParseIdentifierStatement(tokens));
					return node;
				case "if":
					node.Children.Add(ParseIfStatement(tokens));
					return node;
				case "while":
					node.Children.Add(ParseWhileStatement(tokens));
					return node;
				case "for":
					node.Children.Add(ParseForStatement(tokens));
					return node;
				case "interrupt":
					node.Children.Add(ParseInterrupt(tokens));
					return node;
				case "class":
					node.Children.Add(ParseClass(tokens));
					return node;
				case "newline":
				case "eof":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Interrupt ParseInterrupt(IEnumerator<Token> tokens)
		{
			Interrupt node = new Interrupt(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "interrupt":
					node.Children.Add(ParseTerminal(tokens, "interrupt"));
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					node.Children.Add(ParseSimpleBlock(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public Class ParseClass(IEnumerator<Token> tokens)
		{
			Class node = new Class(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "class":
					node.Children.Add(ParseTerminal(tokens, "class"));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseClassBlock(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassBlock ParseClassBlock(IEnumerator<Token> tokens)
		{
			ClassBlock node = new ClassBlock(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "indent":
					node.Children.Add(ParseTerminal(tokens, "indent"));
					node.Children.Add(ParseClassStatements(tokens));
					node.Children.Add(ParseTerminal(tokens, "dedent"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassStatements ParseClassStatements(IEnumerator<Token> tokens)
		{
			ClassStatements node = new ClassStatements(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
				case "newline":
					node.Children.Add(ParseClassStatement(tokens));
					node.Children.Add(ParseClassStatementsP(tokens));
					return node;
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassStatementsP ParseClassStatementsP(IEnumerator<Token> tokens)
		{
			ClassStatementsP node = new ClassStatementsP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "newline":
					node.Children.Add(ParseTerminal(tokens, "newline"));
					node.Children.Add(ParseClassStatement(tokens));
					node.Children.Add(ParseClassStatementsP(tokens));
					return node;
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassStatement ParseClassStatement(IEnumerator<Token> tokens)
		{
			ClassStatement node = new ClassStatement(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseDeclaration(tokens));
					return node;
				case "newline":
					node.Children.Add(ParseTerminal(tokens, "newline"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Declaration ParseDeclaration(IEnumerator<Token> tokens)
		{
			Declaration node = new Declaration(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseType(tokens));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseDefinition(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public IdentifierStatement ParseIdentifierStatement(IEnumerator<Token> tokens)
		{
			IdentifierStatement node = new IdentifierStatement(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "identifier":
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseLIdentifierOperation(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public LIdentifierOperation ParseLIdentifierOperation(IEnumerator<Token> tokens)
		{
			LIdentifierOperation node = new LIdentifierOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "assign":
					node.Children.Add(ParseAssignment(tokens));
					return node;
				case "startDel":
				case "dot":
				case "startBracket":
				case "startCurly":
					node.Children.Add(ParseLSelectorOperation(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public LSelectorOperation ParseLSelectorOperation(IEnumerator<Token> tokens)
		{
			LSelectorOperation node = new LSelectorOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseCall(tokens));
					node.Children.Add(ParseLReturnValueOperation(tokens));
					return node;
				case "dot":
					node.Children.Add(ParseClassAccessor(tokens));
					node.Children.Add(ParseLIdentifierOperation(tokens));
					return node;
				case "startBracket":
					node.Children.Add(ParseElementSelector(tokens));
					node.Children.Add(ParseLIdentifierOperation(tokens));
					return node;
				case "startCurly":
					node.Children.Add(ParseBitSelector(tokens));
					node.Children.Add(ParseAssignment(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public LReturnValueOperation ParseLReturnValueOperation(IEnumerator<Token> tokens)
		{
			LReturnValueOperation node = new LReturnValueOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "newline":
				case "eof":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				case "startDel":
				case "dot":
				case "startBracket":
				case "startCurly":
					node.Children.Add(ParseLSelectorOperation(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ElementSelector ParseElementSelector(IEnumerator<Token> tokens)
		{
			ElementSelector node = new ElementSelector(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startBracket":
					node.Children.Add(ParseTerminal(tokens, "startBracket"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseTerminal(tokens, "endBracket"));
					return node;
				default:
					throw new Exception();
			}
		}

		public BitSelector ParseBitSelector(IEnumerator<Token> tokens)
		{
			BitSelector node = new BitSelector(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startCurly":
					node.Children.Add(ParseTerminal(tokens, "startCurly"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseTerminal(tokens, "endCurly"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassAccessor ParseClassAccessor(IEnumerator<Token> tokens)
		{
			ClassAccessor node = new ClassAccessor(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "dot":
					node.Children.Add(ParseTerminal(tokens, "dot"));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Assignment ParseAssignment(IEnumerator<Token> tokens)
		{
			Assignment node = new Assignment(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "assign":
					node.Children.Add(ParseTerminal(tokens, "assign"));
					node.Children.Add(ParseExpression(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public Call ParseCall(IEnumerator<Token> tokens)
		{
			Call node = new Call(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseParameters(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public IfStatement ParseIfStatement(IEnumerator<Token> tokens)
		{
			IfStatement node = new IfStatement(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "if":
					node.Children.Add(ParseTerminal(tokens, "if"));
					node.Children.Add(ParseCondition(tokens));
					node.Children.Add(ParseSimpleBlock(tokens));
					node.Children.Add(ParseElseStatement(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ElseStatement ParseElseStatement(IEnumerator<Token> tokens)
		{
			ElseStatement node = new ElseStatement(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "else":
					node.Children.Add(ParseTerminal(tokens, "else"));
					node.Children.Add(ParseElseBlock(tokens));
					return node;
				case "newline":
				case "eof":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ElseBlock ParseElseBlock(IEnumerator<Token> tokens)
		{
			ElseBlock node = new ElseBlock(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "if":
					node.Children.Add(ParseIfStatement(tokens));
					return node;
				case "indent":
					node.Children.Add(ParseSimpleBlock(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public WhileStatement ParseWhileStatement(IEnumerator<Token> tokens)
		{
			WhileStatement node = new WhileStatement(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "while":
					node.Children.Add(ParseTerminal(tokens, "while"));
					node.Children.Add(ParseCondition(tokens));
					node.Children.Add(ParseSimpleBlock(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ForStatement ParseForStatement(IEnumerator<Token> tokens)
		{
			ForStatement node = new ForStatement(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "for":
					node.Children.Add(ParseTerminal(tokens, "for"));
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseTerminal(tokens, "simpleType"));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseTerminal(tokens, "from"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseTerminal(tokens, "to"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					node.Children.Add(ParseSimpleBlock(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public Condition ParseCondition(IEnumerator<Token> tokens)
		{
			Condition node = new Condition(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Definition ParseDefinition(IEnumerator<Token> tokens)
		{
			Definition node = new Definition(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseFunctionDefinition(tokens));
					return node;
				case "assign":
					node.Children.Add(ParseAssignment(tokens));
					return node;
				case "newline":
				case "eof":
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public FunctionDefinition ParseFunctionDefinition(IEnumerator<Token> tokens)
		{
			FunctionDefinition node = new FunctionDefinition(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTypedParameters(tokens));
					node.Children.Add(ParseSimpleBlock(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleBlock ParseSimpleBlock(IEnumerator<Token> tokens)
		{
			SimpleBlock node = new SimpleBlock(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "indent":
					node.Children.Add(ParseTerminal(tokens, "indent"));
					node.Children.Add(ParseSimpleStatements(tokens));
					node.Children.Add(ParseTerminal(tokens, "dedent"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypedParameters ParseTypedParameters(IEnumerator<Token> tokens)
		{
			TypedParameters node = new TypedParameters(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseTypedParametersF(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypedParametersF ParseTypedParametersF(IEnumerator<Token> tokens)
		{
			TypedParametersF node = new TypedParametersF(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseType(tokens));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseTypedParametersP(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypedParametersP ParseTypedParametersP(IEnumerator<Token> tokens)
		{
			TypedParametersP node = new TypedParametersP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "sep"));
					node.Children.Add(ParseType(tokens));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseTypedParametersP(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Type ParseType(IEnumerator<Token> tokens)
		{
			Type node = new Type(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
					node.Children.Add(ParseTerminal(tokens, "simpleType"));
					node.Children.Add(ParseTypeParameters(tokens));
					node.Children.Add(ParseArrayType(tokens));
					return node;
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseType(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseTypeParametersF(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					node.Children.Add(ParseArrayType(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ArrayType ParseArrayType(IEnumerator<Token> tokens)
		{
			ArrayType node = new ArrayType(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startBracket":
					node.Children.Add(ParseTerminal(tokens, "startBracket"));
					node.Children.Add(ParseArraySize(tokens));
					node.Children.Add(ParseTerminal(tokens, "endBracket"));
					return node;
				case "identifier":
				case "endDel":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ArraySize ParseArraySize(IEnumerator<Token> tokens)
		{
			ArraySize node = new ArraySize(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseExpression(tokens));
					return node;
				case "endBracket":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypeParameters ParseTypeParameters(IEnumerator<Token> tokens)
		{
			TypeParameters node = new TypeParameters(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseTypeParametersF(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				case "startBracket":
				case "identifier":
				case "endDel":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypeParametersF ParseTypeParametersF(IEnumerator<Token> tokens)
		{
			TypeParametersF node = new TypeParametersF(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseType(tokens));
					node.Children.Add(ParseTypeParametersP(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypeParametersP ParseTypeParametersP(IEnumerator<Token> tokens)
		{
			TypeParametersP node = new TypeParametersP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "sep"));
					node.Children.Add(ParseType(tokens));
					node.Children.Add(ParseTypeParametersP(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleStatements ParseSimpleStatements(IEnumerator<Token> tokens)
		{
			SimpleStatements node = new SimpleStatements(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
				case "assign":
				case "if":
				case "while":
				case "return":
				case "newline":
				case "dedent":
					node.Children.Add(ParseSimpleStatement(tokens));
					node.Children.Add(ParseSimpleStatementsP(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleStatementsP ParseSimpleStatementsP(IEnumerator<Token> tokens)
		{
			SimpleStatementsP node = new SimpleStatementsP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "newline":
					node.Children.Add(ParseTerminal(tokens, "newline"));
					node.Children.Add(ParseSimpleStatement(tokens));
					node.Children.Add(ParseSimpleStatementsP(tokens));
					return node;
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleStatement ParseSimpleStatement(IEnumerator<Token> tokens)
		{
			SimpleStatement node = new SimpleStatement(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseSimpleDeclaration(tokens));
					return node;
				case "assign":
					node.Children.Add(ParseAssignment(tokens));
					return node;
				case "if":
					node.Children.Add(ParseIfStatement(tokens));
					return node;
				case "while":
					node.Children.Add(ParseWhileStatement(tokens));
					return node;
				case "return":
					node.Children.Add(ParseReturnStatement(tokens));
					return node;
				case "newline":
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ReturnStatement ParseReturnStatement(IEnumerator<Token> tokens)
		{
			ReturnStatement node = new ReturnStatement(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "return":
					node.Children.Add(ParseTerminal(tokens, "return"));
					node.Children.Add(ParseExpression(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleDeclaration ParseSimpleDeclaration(IEnumerator<Token> tokens)
		{
			SimpleDeclaration node = new SimpleDeclaration(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseType(tokens));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseSimpleDefinition(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleDefinition ParseSimpleDefinition(IEnumerator<Token> tokens)
		{
			SimpleDefinition node = new SimpleDefinition(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "assign":
					node.Children.Add(ParseTerminal(tokens, "assign"));
					node.Children.Add(ParseExpression(tokens));
					return node;
				case "newline":
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Expression ParseExpression(IEnumerator<Token> tokens)
		{
			Expression node = new Expression(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseOrOperation(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public OrOperation ParseOrOperation(IEnumerator<Token> tokens)
		{
			OrOperation node = new OrOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseAndOperation(tokens));
					node.Children.Add(ParseOrOperationP(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public OrOperationP ParseOrOperationP(IEnumerator<Token> tokens)
		{
			OrOperationP node = new OrOperationP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "or":
					node.Children.Add(ParseTerminal(tokens, "or"));
					node.Children.Add(ParseAndOperation(tokens));
					node.Children.Add(ParseOrOperationP(tokens));
					return node;
				case "endDel":
				case "endBracket":
				case "endCurly":
				case "newline":
				case "eof":
				case "dedent":
				case "to":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public AndOperation ParseAndOperation(IEnumerator<Token> tokens)
		{
			AndOperation node = new AndOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseEqualityOperation(tokens));
					node.Children.Add(ParseAndOperationP(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public AndOperationP ParseAndOperationP(IEnumerator<Token> tokens)
		{
			AndOperationP node = new AndOperationP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "and":
					node.Children.Add(ParseTerminal(tokens, "and"));
					node.Children.Add(ParseEqualityOperation(tokens));
					node.Children.Add(ParseAndOperationP(tokens));
					return node;
				case "or":
				case "endDel":
				case "endBracket":
				case "endCurly":
				case "newline":
				case "eof":
				case "dedent":
				case "to":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public EqualityOperation ParseEqualityOperation(IEnumerator<Token> tokens)
		{
			EqualityOperation node = new EqualityOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseRelationalOperation(tokens));
					node.Children.Add(ParseEqualityOperationP(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public EqualityOperationP ParseEqualityOperationP(IEnumerator<Token> tokens)
		{
			EqualityOperationP node = new EqualityOperationP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "equality":
					node.Children.Add(ParseTerminal(tokens, "equality"));
					node.Children.Add(ParseRelationalOperation(tokens));
					node.Children.Add(ParseEqualityOperationP(tokens));
					return node;
				case "and":
				case "or":
				case "endDel":
				case "endBracket":
				case "endCurly":
				case "newline":
				case "eof":
				case "dedent":
				case "to":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public RelationalOperation ParseRelationalOperation(IEnumerator<Token> tokens)
		{
			RelationalOperation node = new RelationalOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseAddSubOperation(tokens));
					node.Children.Add(ParseRelationalOperationP(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public RelationalOperationP ParseRelationalOperationP(IEnumerator<Token> tokens)
		{
			RelationalOperationP node = new RelationalOperationP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "relational":
					node.Children.Add(ParseTerminal(tokens, "relational"));
					node.Children.Add(ParseAddSubOperation(tokens));
					node.Children.Add(ParseRelationalOperationP(tokens));
					return node;
				case "equality":
				case "and":
				case "or":
				case "endDel":
				case "endBracket":
				case "endCurly":
				case "newline":
				case "eof":
				case "dedent":
				case "to":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public AddSubOperation ParseAddSubOperation(IEnumerator<Token> tokens)
		{
			AddSubOperation node = new AddSubOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseMultDivOperation(tokens));
					node.Children.Add(ParseAddSubOperationP(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public AddSubOperationP ParseAddSubOperationP(IEnumerator<Token> tokens)
		{
			AddSubOperationP node = new AddSubOperationP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "addSub":
					node.Children.Add(ParseTerminal(tokens, "addSub"));
					node.Children.Add(ParseMultDivOperation(tokens));
					node.Children.Add(ParseAddSubOperationP(tokens));
					return node;
				case "relational":
				case "equality":
				case "and":
				case "or":
				case "endDel":
				case "endBracket":
				case "endCurly":
				case "newline":
				case "eof":
				case "dedent":
				case "to":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public MultDivOperation ParseMultDivOperation(IEnumerator<Token> tokens)
		{
			MultDivOperation node = new MultDivOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParsePrimaryOperation(tokens));
					node.Children.Add(ParseMultDivOperationP(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public MultDivOperationP ParseMultDivOperationP(IEnumerator<Token> tokens)
		{
			MultDivOperationP node = new MultDivOperationP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "multDiv":
					node.Children.Add(ParseTerminal(tokens, "multDiv"));
					node.Children.Add(ParsePrimaryOperation(tokens));
					node.Children.Add(ParseMultDivOperationP(tokens));
					return node;
				case "addSub":
				case "relational":
				case "equality":
				case "and":
				case "or":
				case "endDel":
				case "endBracket":
				case "endCurly":
				case "newline":
				case "eof":
				case "dedent":
				case "to":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public PrimaryOperation ParsePrimaryOperation(IEnumerator<Token> tokens)
		{
			PrimaryOperation node = new PrimaryOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				case "identifier":
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseRSelectorOperation(tokens));
					return node;
				case "intLiteral":
					node.Children.Add(ParseTerminal(tokens, "intLiteral"));
					return node;
				case "boolLiteral":
					node.Children.Add(ParseTerminal(tokens, "boolLiteral"));
					return node;
				case "register":
					node.Children.Add(ParseRegister(tokens));
					node.Children.Add(ParseOptionalBitSelector(tokens));
					return node;
				case "startBracket":
					node.Children.Add(ParseArray(tokens));
					node.Children.Add(ParseOptionalElementSelector(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public Register ParseRegister(IEnumerator<Token> tokens)
		{
			Register node = new Register(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "register":
					node.Children.Add(ParseTerminal(tokens, "register"));
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				default:
					throw new Exception();
			}
		}

		public OptionalBitSelector ParseOptionalBitSelector(IEnumerator<Token> tokens)
		{
			OptionalBitSelector node = new OptionalBitSelector(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startCurly":
					node.Children.Add(ParseBitSelector(tokens));
					return node;
				case "multDiv":
				case "addSub":
				case "relational":
				case "equality":
				case "and":
				case "or":
				case "endDel":
				case "endBracket":
				case "endCurly":
				case "newline":
				case "eof":
				case "dedent":
				case "to":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Array ParseArray(IEnumerator<Token> tokens)
		{
			Array node = new Array(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startBracket":
					node.Children.Add(ParseTerminal(tokens, "startBracket"));
					node.Children.Add(ParseArrayF(tokens));
					node.Children.Add(ParseTerminal(tokens, "endBracket"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ArrayF ParseArrayF(IEnumerator<Token> tokens)
		{
			ArrayF node = new ArrayF(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseArrayP(tokens));
					return node;
				case "endBracket":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ArrayP ParseArrayP(IEnumerator<Token> tokens)
		{
			ArrayP node = new ArrayP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "sep"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseArrayP(tokens));
					return node;
				case "endBracket":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public OptionalElementSelector ParseOptionalElementSelector(IEnumerator<Token> tokens)
		{
			OptionalElementSelector node = new OptionalElementSelector(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startBracket":
					node.Children.Add(ParseElementSelector(tokens));
					node.Children.Add(ParseRSelectorOperation(tokens));
					return node;
				case "multDiv":
				case "addSub":
				case "relational":
				case "equality":
				case "and":
				case "or":
				case "endDel":
				case "endBracket":
				case "endCurly":
				case "newline":
				case "eof":
				case "dedent":
				case "to":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public RSelectorOperation ParseRSelectorOperation(IEnumerator<Token> tokens)
		{
			RSelectorOperation node = new RSelectorOperation(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseCall(tokens));
					node.Children.Add(ParseRSelectorOperation(tokens));
					return node;
				case "dot":
					node.Children.Add(ParseClassAccessor(tokens));
					node.Children.Add(ParseRSelectorOperation(tokens));
					return node;
				case "startBracket":
					node.Children.Add(ParseElementSelector(tokens));
					node.Children.Add(ParseRSelectorOperation(tokens));
					return node;
				case "startCurly":
					node.Children.Add(ParseBitSelector(tokens));
					return node;
				case "multDiv":
				case "addSub":
				case "relational":
				case "equality":
				case "and":
				case "or":
				case "endDel":
				case "endBracket":
				case "endCurly":
				case "newline":
				case "eof":
				case "dedent":
				case "to":
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public Parameters ParseParameters(IEnumerator<Token> tokens)
		{
			Parameters node = new Parameters(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseParametersF(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ParametersF ParseParametersF(IEnumerator<Token> tokens)
		{
			ParametersF node = new ParametersF(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseParametersP(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ParametersP ParseParametersP(IEnumerator<Token> tokens)
		{
			ParametersP node = new ParametersP(){ Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "sep"));
					node.Children.Add(ParseExpression(tokens));
					node.Children.Add(ParseParametersP(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}
	}
}
