using Compiler.Data;

namespace Compiler.Parsing
{
	public abstract partial class Visitor<T> 
	{
		public virtual T Visit(ProgramNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(StatementsNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(StatementsPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(StatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(InterruptNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassBlockNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassStatementsNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassStatementsPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(DeclarationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IdentifierStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(LIdentifierOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(LSelectorOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(LReturnValueOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ElementSelectorNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(BitSelectorNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassAccessorNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AssignmentNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(CallNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IfStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ElseStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ElseBlockNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(WhileStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ForStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ConditionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(DefinitionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(FunctionDefinitionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleBlockNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypedParametersNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypedParametersFNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypedParametersPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypeNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArrayTypeNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArraySizeNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypeParametersNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypeParametersFNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypeParametersPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleStatementsNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleStatementsPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ReturnStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleDeclarationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleDefinitionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ExpressionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(OrOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(OrOperationPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AndOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AndOperationPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(EqualityOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(EqualityOperationPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(RelationalOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(RelationalOperationPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AddSubOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AddSubOperationPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(MultDivOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(MultDivOperationPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(PrimaryOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(RegisterNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(OptionalBitSelectorNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArrayNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArrayFNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArrayPNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(OptionalElementSelectorNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(RSelectorOperationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ParametersNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ParametersFNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ParametersPNode node)
		{
			return Visit((Node)node);
		}
	}
}
