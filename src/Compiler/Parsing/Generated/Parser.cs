using System;
using System.Collections.Generic;
using Compiler.Data;

namespace Compiler.Parsing
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

		public ProgramNode ParseProgramNode(IEnumerator<Token> tokens)
		{
			ProgramNode node = new ProgramNode(){ Name = "Program", Children = new List<Node>() };
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
					node.Children.Add(ParseStatementsNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "eof"));
					return node;
				default:
					throw new Exception();
			}
		}

		public StatementsNode ParseStatementsNode(IEnumerator<Token> tokens)
		{
			StatementsNode node = new StatementsNode(){ Name = "Statements", Children = new List<Node>() };
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
					node.Children.Add(ParseStatementNode(tokens));
					node.Children.Add(ParseStatementsPNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public StatementsPNode ParseStatementsPNode(IEnumerator<Token> tokens)
		{
			StatementsPNode node = new StatementsPNode(){ Name = "StatementsP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "newline":
					node.Children.Add(ParseTerminal(tokens, "newline"));
					node.Children.Add(ParseStatementNode(tokens));
					node.Children.Add(ParseStatementsPNode(tokens));
					return node;
				case "eof":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public StatementNode ParseStatementNode(IEnumerator<Token> tokens)
		{
			StatementNode node = new StatementNode(){ Name = "Statement", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseDeclarationNode(tokens));
					return node;
				case "identifier":
					node.Children.Add(ParseIdentifierStatementNode(tokens));
					return node;
				case "if":
					node.Children.Add(ParseIfStatementNode(tokens));
					return node;
				case "while":
					node.Children.Add(ParseWhileStatementNode(tokens));
					return node;
				case "for":
					node.Children.Add(ParseForStatementNode(tokens));
					return node;
				case "interrupt":
					node.Children.Add(ParseInterruptNode(tokens));
					return node;
				case "class":
					node.Children.Add(ParseClassNode(tokens));
					return node;
				case "newline":
				case "eof":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public InterruptNode ParseInterruptNode(IEnumerator<Token> tokens)
		{
			InterruptNode node = new InterruptNode(){ Name = "Interrupt", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "interrupt":
					node.Children.Add(ParseTerminal(tokens, "interrupt"));
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					node.Children.Add(ParseSimpleBlockNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassNode ParseClassNode(IEnumerator<Token> tokens)
		{
			ClassNode node = new ClassNode(){ Name = "Class", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "class":
					node.Children.Add(ParseTerminal(tokens, "class"));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseClassBlockNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassBlockNode ParseClassBlockNode(IEnumerator<Token> tokens)
		{
			ClassBlockNode node = new ClassBlockNode(){ Name = "ClassBlock", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "indent":
					node.Children.Add(ParseTerminal(tokens, "indent"));
					node.Children.Add(ParseClassStatementsNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "dedent"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassStatementsNode ParseClassStatementsNode(IEnumerator<Token> tokens)
		{
			ClassStatementsNode node = new ClassStatementsNode(){ Name = "ClassStatements", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
				case "newline":
					node.Children.Add(ParseClassStatementNode(tokens));
					node.Children.Add(ParseClassStatementsPNode(tokens));
					return node;
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassStatementsPNode ParseClassStatementsPNode(IEnumerator<Token> tokens)
		{
			ClassStatementsPNode node = new ClassStatementsPNode(){ Name = "ClassStatementsP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "newline":
					node.Children.Add(ParseTerminal(tokens, "newline"));
					node.Children.Add(ParseClassStatementNode(tokens));
					node.Children.Add(ParseClassStatementsPNode(tokens));
					return node;
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassStatementNode ParseClassStatementNode(IEnumerator<Token> tokens)
		{
			ClassStatementNode node = new ClassStatementNode(){ Name = "ClassStatement", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseDeclarationNode(tokens));
					return node;
				case "newline":
					node.Children.Add(ParseTerminal(tokens, "newline"));
					return node;
				default:
					throw new Exception();
			}
		}

		public DeclarationNode ParseDeclarationNode(IEnumerator<Token> tokens)
		{
			DeclarationNode node = new DeclarationNode(){ Name = "Declaration", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseTypeNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseDefinitionNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public IdentifierStatementNode ParseIdentifierStatementNode(IEnumerator<Token> tokens)
		{
			IdentifierStatementNode node = new IdentifierStatementNode(){ Name = "IdentifierStatement", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "identifier":
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseLIdentifierOperationNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public LIdentifierOperationNode ParseLIdentifierOperationNode(IEnumerator<Token> tokens)
		{
			LIdentifierOperationNode node = new LIdentifierOperationNode(){ Name = "LIdentifierOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "assign":
					node.Children.Add(ParseAssignmentNode(tokens));
					return node;
				case "startDel":
				case "dot":
				case "startBracket":
				case "startCurly":
					node.Children.Add(ParseLSelectorOperationNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public LSelectorOperationNode ParseLSelectorOperationNode(IEnumerator<Token> tokens)
		{
			LSelectorOperationNode node = new LSelectorOperationNode(){ Name = "LSelectorOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseCallNode(tokens));
					node.Children.Add(ParseLReturnValueOperationNode(tokens));
					return node;
				case "dot":
					node.Children.Add(ParseClassAccessorNode(tokens));
					node.Children.Add(ParseLIdentifierOperationNode(tokens));
					return node;
				case "startBracket":
					node.Children.Add(ParseElementSelectorNode(tokens));
					node.Children.Add(ParseLIdentifierOperationNode(tokens));
					return node;
				case "startCurly":
					node.Children.Add(ParseBitSelectorNode(tokens));
					node.Children.Add(ParseAssignmentNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public LReturnValueOperationNode ParseLReturnValueOperationNode(IEnumerator<Token> tokens)
		{
			LReturnValueOperationNode node = new LReturnValueOperationNode(){ Name = "LReturnValueOperation", Children = new List<Node>() };
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
					node.Children.Add(ParseLSelectorOperationNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ElementSelectorNode ParseElementSelectorNode(IEnumerator<Token> tokens)
		{
			ElementSelectorNode node = new ElementSelectorNode(){ Name = "ElementSelector", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startBracket":
					node.Children.Add(ParseTerminal(tokens, "startBracket"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endBracket"));
					return node;
				default:
					throw new Exception();
			}
		}

		public BitSelectorNode ParseBitSelectorNode(IEnumerator<Token> tokens)
		{
			BitSelectorNode node = new BitSelectorNode(){ Name = "BitSelector", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startCurly":
					node.Children.Add(ParseTerminal(tokens, "startCurly"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endCurly"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ClassAccessorNode ParseClassAccessorNode(IEnumerator<Token> tokens)
		{
			ClassAccessorNode node = new ClassAccessorNode(){ Name = "ClassAccessor", Children = new List<Node>() };
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

		public AssignmentNode ParseAssignmentNode(IEnumerator<Token> tokens)
		{
			AssignmentNode node = new AssignmentNode(){ Name = "Assignment", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "assign":
					node.Children.Add(ParseTerminal(tokens, "assign"));
					node.Children.Add(ParseExpressionNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public CallNode ParseCallNode(IEnumerator<Token> tokens)
		{
			CallNode node = new CallNode(){ Name = "Call", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseParametersNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public IfStatementNode ParseIfStatementNode(IEnumerator<Token> tokens)
		{
			IfStatementNode node = new IfStatementNode(){ Name = "IfStatement", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "if":
					node.Children.Add(ParseTerminal(tokens, "if"));
					node.Children.Add(ParseConditionNode(tokens));
					node.Children.Add(ParseSimpleBlockNode(tokens));
					node.Children.Add(ParseElseStatementNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ElseStatementNode ParseElseStatementNode(IEnumerator<Token> tokens)
		{
			ElseStatementNode node = new ElseStatementNode(){ Name = "ElseStatement", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "else":
					node.Children.Add(ParseTerminal(tokens, "else"));
					node.Children.Add(ParseElseBlockNode(tokens));
					return node;
				case "newline":
				case "eof":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ElseBlockNode ParseElseBlockNode(IEnumerator<Token> tokens)
		{
			ElseBlockNode node = new ElseBlockNode(){ Name = "ElseBlock", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "if":
					node.Children.Add(ParseIfStatementNode(tokens));
					return node;
				case "indent":
					node.Children.Add(ParseSimpleBlockNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public WhileStatementNode ParseWhileStatementNode(IEnumerator<Token> tokens)
		{
			WhileStatementNode node = new WhileStatementNode(){ Name = "WhileStatement", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "while":
					node.Children.Add(ParseTerminal(tokens, "while"));
					node.Children.Add(ParseConditionNode(tokens));
					node.Children.Add(ParseSimpleBlockNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ForStatementNode ParseForStatementNode(IEnumerator<Token> tokens)
		{
			ForStatementNode node = new ForStatementNode(){ Name = "ForStatement", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "for":
					node.Children.Add(ParseTerminal(tokens, "for"));
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseTerminal(tokens, "simpleType"));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseTerminal(tokens, "from"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "to"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					node.Children.Add(ParseSimpleBlockNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ConditionNode ParseConditionNode(IEnumerator<Token> tokens)
		{
			ConditionNode node = new ConditionNode(){ Name = "Condition", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				default:
					throw new Exception();
			}
		}

		public DefinitionNode ParseDefinitionNode(IEnumerator<Token> tokens)
		{
			DefinitionNode node = new DefinitionNode(){ Name = "Definition", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseFunctionDefinitionNode(tokens));
					return node;
				case "assign":
					node.Children.Add(ParseAssignmentNode(tokens));
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

		public FunctionDefinitionNode ParseFunctionDefinitionNode(IEnumerator<Token> tokens)
		{
			FunctionDefinitionNode node = new FunctionDefinitionNode(){ Name = "FunctionDefinition", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTypedParametersNode(tokens));
					node.Children.Add(ParseSimpleBlockNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleBlockNode ParseSimpleBlockNode(IEnumerator<Token> tokens)
		{
			SimpleBlockNode node = new SimpleBlockNode(){ Name = "SimpleBlock", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "indent":
					node.Children.Add(ParseTerminal(tokens, "indent"));
					node.Children.Add(ParseSimpleStatementsNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "dedent"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypedParametersNode ParseTypedParametersNode(IEnumerator<Token> tokens)
		{
			TypedParametersNode node = new TypedParametersNode(){ Name = "TypedParameters", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseTypedParametersFNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypedParametersFNode ParseTypedParametersFNode(IEnumerator<Token> tokens)
		{
			TypedParametersFNode node = new TypedParametersFNode(){ Name = "TypedParametersF", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseTypeNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseTypedParametersPNode(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypedParametersPNode ParseTypedParametersPNode(IEnumerator<Token> tokens)
		{
			TypedParametersPNode node = new TypedParametersPNode(){ Name = "TypedParametersP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "sep"));
					node.Children.Add(ParseTypeNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseTypedParametersPNode(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypeNode ParseTypeNode(IEnumerator<Token> tokens)
		{
			TypeNode node = new TypeNode(){ Name = "Type", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
					node.Children.Add(ParseTerminal(tokens, "simpleType"));
					node.Children.Add(ParseTypeParametersNode(tokens));
					node.Children.Add(ParseArrayTypeNode(tokens));
					return node;
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseTypeNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseTypeParametersFNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					node.Children.Add(ParseArrayTypeNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public ArrayTypeNode ParseArrayTypeNode(IEnumerator<Token> tokens)
		{
			ArrayTypeNode node = new ArrayTypeNode(){ Name = "ArrayType", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startBracket":
					node.Children.Add(ParseTerminal(tokens, "startBracket"));
					node.Children.Add(ParseArraySizeNode(tokens));
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

		public ArraySizeNode ParseArraySizeNode(IEnumerator<Token> tokens)
		{
			ArraySizeNode node = new ArraySizeNode(){ Name = "ArraySize", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseExpressionNode(tokens));
					return node;
				case "endBracket":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypeParametersNode ParseTypeParametersNode(IEnumerator<Token> tokens)
		{
			TypeParametersNode node = new TypeParametersNode(){ Name = "TypeParameters", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseTypeParametersFNode(tokens));
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

		public TypeParametersFNode ParseTypeParametersFNode(IEnumerator<Token> tokens)
		{
			TypeParametersFNode node = new TypeParametersFNode(){ Name = "TypeParametersF", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseTypeNode(tokens));
					node.Children.Add(ParseTypeParametersPNode(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public TypeParametersPNode ParseTypeParametersPNode(IEnumerator<Token> tokens)
		{
			TypeParametersPNode node = new TypeParametersPNode(){ Name = "TypeParametersP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "sep"));
					node.Children.Add(ParseTypeNode(tokens));
					node.Children.Add(ParseTypeParametersPNode(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleStatementsNode ParseSimpleStatementsNode(IEnumerator<Token> tokens)
		{
			SimpleStatementsNode node = new SimpleStatementsNode(){ Name = "SimpleStatements", Children = new List<Node>() };
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
					node.Children.Add(ParseSimpleStatementNode(tokens));
					node.Children.Add(ParseSimpleStatementsPNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleStatementsPNode ParseSimpleStatementsPNode(IEnumerator<Token> tokens)
		{
			SimpleStatementsPNode node = new SimpleStatementsPNode(){ Name = "SimpleStatementsP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "newline":
					node.Children.Add(ParseTerminal(tokens, "newline"));
					node.Children.Add(ParseSimpleStatementNode(tokens));
					node.Children.Add(ParseSimpleStatementsPNode(tokens));
					return node;
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleStatementNode ParseSimpleStatementNode(IEnumerator<Token> tokens)
		{
			SimpleStatementNode node = new SimpleStatementNode(){ Name = "SimpleStatement", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseSimpleDeclarationNode(tokens));
					return node;
				case "assign":
					node.Children.Add(ParseAssignmentNode(tokens));
					return node;
				case "if":
					node.Children.Add(ParseIfStatementNode(tokens));
					return node;
				case "while":
					node.Children.Add(ParseWhileStatementNode(tokens));
					return node;
				case "return":
					node.Children.Add(ParseReturnStatementNode(tokens));
					return node;
				case "newline":
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ReturnStatementNode ParseReturnStatementNode(IEnumerator<Token> tokens)
		{
			ReturnStatementNode node = new ReturnStatementNode(){ Name = "ReturnStatement", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "return":
					node.Children.Add(ParseTerminal(tokens, "return"));
					node.Children.Add(ParseExpressionNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleDeclarationNode ParseSimpleDeclarationNode(IEnumerator<Token> tokens)
		{
			SimpleDeclarationNode node = new SimpleDeclarationNode(){ Name = "SimpleDeclaration", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "simpleType":
				case "startDel":
					node.Children.Add(ParseTypeNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseSimpleDefinitionNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public SimpleDefinitionNode ParseSimpleDefinitionNode(IEnumerator<Token> tokens)
		{
			SimpleDefinitionNode node = new SimpleDefinitionNode(){ Name = "SimpleDefinition", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "assign":
					node.Children.Add(ParseTerminal(tokens, "assign"));
					node.Children.Add(ParseExpressionNode(tokens));
					return node;
				case "newline":
				case "dedent":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ExpressionNode ParseExpressionNode(IEnumerator<Token> tokens)
		{
			ExpressionNode node = new ExpressionNode(){ Name = "Expression", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseOrOperationNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public OrOperationNode ParseOrOperationNode(IEnumerator<Token> tokens)
		{
			OrOperationNode node = new OrOperationNode(){ Name = "OrOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseAndOperationNode(tokens));
					node.Children.Add(ParseOrOperationPNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public OrOperationPNode ParseOrOperationPNode(IEnumerator<Token> tokens)
		{
			OrOperationPNode node = new OrOperationPNode(){ Name = "OrOperationP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "or":
					node.Children.Add(ParseTerminal(tokens, "or"));
					node.Children.Add(ParseAndOperationNode(tokens));
					node.Children.Add(ParseOrOperationPNode(tokens));
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

		public AndOperationNode ParseAndOperationNode(IEnumerator<Token> tokens)
		{
			AndOperationNode node = new AndOperationNode(){ Name = "AndOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseEqualityOperationNode(tokens));
					node.Children.Add(ParseAndOperationPNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public AndOperationPNode ParseAndOperationPNode(IEnumerator<Token> tokens)
		{
			AndOperationPNode node = new AndOperationPNode(){ Name = "AndOperationP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "and":
					node.Children.Add(ParseTerminal(tokens, "and"));
					node.Children.Add(ParseEqualityOperationNode(tokens));
					node.Children.Add(ParseAndOperationPNode(tokens));
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

		public EqualityOperationNode ParseEqualityOperationNode(IEnumerator<Token> tokens)
		{
			EqualityOperationNode node = new EqualityOperationNode(){ Name = "EqualityOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseRelationalOperationNode(tokens));
					node.Children.Add(ParseEqualityOperationPNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public EqualityOperationPNode ParseEqualityOperationPNode(IEnumerator<Token> tokens)
		{
			EqualityOperationPNode node = new EqualityOperationPNode(){ Name = "EqualityOperationP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "equality":
					node.Children.Add(ParseTerminal(tokens, "equality"));
					node.Children.Add(ParseRelationalOperationNode(tokens));
					node.Children.Add(ParseEqualityOperationPNode(tokens));
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

		public RelationalOperationNode ParseRelationalOperationNode(IEnumerator<Token> tokens)
		{
			RelationalOperationNode node = new RelationalOperationNode(){ Name = "RelationalOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseAddSubOperationNode(tokens));
					node.Children.Add(ParseRelationalOperationPNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public RelationalOperationPNode ParseRelationalOperationPNode(IEnumerator<Token> tokens)
		{
			RelationalOperationPNode node = new RelationalOperationPNode(){ Name = "RelationalOperationP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "relational":
					node.Children.Add(ParseTerminal(tokens, "relational"));
					node.Children.Add(ParseAddSubOperationNode(tokens));
					node.Children.Add(ParseRelationalOperationPNode(tokens));
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

		public AddSubOperationNode ParseAddSubOperationNode(IEnumerator<Token> tokens)
		{
			AddSubOperationNode node = new AddSubOperationNode(){ Name = "AddSubOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseMultDivOperationNode(tokens));
					node.Children.Add(ParseAddSubOperationPNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public AddSubOperationPNode ParseAddSubOperationPNode(IEnumerator<Token> tokens)
		{
			AddSubOperationPNode node = new AddSubOperationPNode(){ Name = "AddSubOperationP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "addSub":
					node.Children.Add(ParseTerminal(tokens, "addSub"));
					node.Children.Add(ParseMultDivOperationNode(tokens));
					node.Children.Add(ParseAddSubOperationPNode(tokens));
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

		public MultDivOperationNode ParseMultDivOperationNode(IEnumerator<Token> tokens)
		{
			MultDivOperationNode node = new MultDivOperationNode(){ Name = "MultDivOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParsePrimaryOperationNode(tokens));
					node.Children.Add(ParseMultDivOperationPNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public MultDivOperationPNode ParseMultDivOperationPNode(IEnumerator<Token> tokens)
		{
			MultDivOperationPNode node = new MultDivOperationPNode(){ Name = "MultDivOperationP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "multDiv":
					node.Children.Add(ParseTerminal(tokens, "multDiv"));
					node.Children.Add(ParsePrimaryOperationNode(tokens));
					node.Children.Add(ParseMultDivOperationPNode(tokens));
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

		public PrimaryOperationNode ParsePrimaryOperationNode(IEnumerator<Token> tokens)
		{
			PrimaryOperationNode node = new PrimaryOperationNode(){ Name = "PrimaryOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				case "identifier":
					node.Children.Add(ParseTerminal(tokens, "identifier"));
					node.Children.Add(ParseRSelectorOperationNode(tokens));
					return node;
				case "intLiteral":
					node.Children.Add(ParseTerminal(tokens, "intLiteral"));
					return node;
				case "boolLiteral":
					node.Children.Add(ParseTerminal(tokens, "boolLiteral"));
					return node;
				case "register":
					node.Children.Add(ParseRegisterNode(tokens));
					node.Children.Add(ParseOptionalBitSelectorNode(tokens));
					return node;
				case "startBracket":
					node.Children.Add(ParseArrayNode(tokens));
					node.Children.Add(ParseOptionalElementSelectorNode(tokens));
					return node;
				default:
					throw new Exception();
			}
		}

		public RegisterNode ParseRegisterNode(IEnumerator<Token> tokens)
		{
			RegisterNode node = new RegisterNode(){ Name = "Register", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "register":
					node.Children.Add(ParseTerminal(tokens, "register"));
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				default:
					throw new Exception();
			}
		}

		public OptionalBitSelectorNode ParseOptionalBitSelectorNode(IEnumerator<Token> tokens)
		{
			OptionalBitSelectorNode node = new OptionalBitSelectorNode(){ Name = "OptionalBitSelector", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startCurly":
					node.Children.Add(ParseBitSelectorNode(tokens));
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

		public ArrayNode ParseArrayNode(IEnumerator<Token> tokens)
		{
			ArrayNode node = new ArrayNode(){ Name = "Array", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startBracket":
					node.Children.Add(ParseTerminal(tokens, "startBracket"));
					node.Children.Add(ParseArrayFNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endBracket"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ArrayFNode ParseArrayFNode(IEnumerator<Token> tokens)
		{
			ArrayFNode node = new ArrayFNode(){ Name = "ArrayF", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseArrayPNode(tokens));
					return node;
				case "endBracket":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ArrayPNode ParseArrayPNode(IEnumerator<Token> tokens)
		{
			ArrayPNode node = new ArrayPNode(){ Name = "ArrayP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "sep"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseArrayPNode(tokens));
					return node;
				case "endBracket":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public OptionalElementSelectorNode ParseOptionalElementSelectorNode(IEnumerator<Token> tokens)
		{
			OptionalElementSelectorNode node = new OptionalElementSelectorNode(){ Name = "OptionalElementSelector", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startBracket":
					node.Children.Add(ParseElementSelectorNode(tokens));
					node.Children.Add(ParseRSelectorOperationNode(tokens));
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

		public RSelectorOperationNode ParseRSelectorOperationNode(IEnumerator<Token> tokens)
		{
			RSelectorOperationNode node = new RSelectorOperationNode(){ Name = "RSelectorOperation", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseCallNode(tokens));
					node.Children.Add(ParseRSelectorOperationNode(tokens));
					return node;
				case "dot":
					node.Children.Add(ParseClassAccessorNode(tokens));
					node.Children.Add(ParseRSelectorOperationNode(tokens));
					return node;
				case "startBracket":
					node.Children.Add(ParseElementSelectorNode(tokens));
					node.Children.Add(ParseRSelectorOperationNode(tokens));
					return node;
				case "startCurly":
					node.Children.Add(ParseBitSelectorNode(tokens));
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

		public ParametersNode ParseParametersNode(IEnumerator<Token> tokens)
		{
			ParametersNode node = new ParametersNode(){ Name = "Parameters", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
					node.Children.Add(ParseTerminal(tokens, "startDel"));
					node.Children.Add(ParseParametersFNode(tokens));
					node.Children.Add(ParseTerminal(tokens, "endDel"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ParametersFNode ParseParametersFNode(IEnumerator<Token> tokens)
		{
			ParametersFNode node = new ParametersFNode(){ Name = "ParametersF", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "startDel":
				case "identifier":
				case "intLiteral":
				case "boolLiteral":
				case "register":
				case "startBracket":
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseParametersPNode(tokens));
					return node;
				case "endDel":
					node.Children.Add(ParseTerminal(tokens, "EPSILON"));
					return node;
				default:
					throw new Exception();
			}
		}

		public ParametersPNode ParseParametersPNode(IEnumerator<Token> tokens)
		{
			ParametersPNode node = new ParametersPNode(){ Name = "ParametersP", Children = new List<Node>() };
			switch(tokens.Current.Name)
			{
				case "sep":
					node.Children.Add(ParseTerminal(tokens, "sep"));
					node.Children.Add(ParseExpressionNode(tokens));
					node.Children.Add(ParseParametersPNode(tokens));
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
