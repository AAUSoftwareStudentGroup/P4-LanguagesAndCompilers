using Compiler.Shared;
using Compiler.Data.AST;

namespace Compiler.Visitors
{
	public abstract partial class Visitor<T> 
	{
		public virtual T Visit(StatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(CompoundStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ScopedLevelStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(NewlineNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ForStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(WhileStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AssignmentNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SingleBitAssignmentNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(CompoundScopedLevelStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IfStatementChainsNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(LeftValueNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ObjectNamesNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ElementAccessorNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArraylvAccessorNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ExpressionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ProcedecureCallNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ParenthesisExpressionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(returnExpressionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IntegerExpressionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AddOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SubOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(MulOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(DivOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ModOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(PowOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(BooleanExpressionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(EqOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(LessThanOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(GreaterThanOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(LessThanOrEqOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(GreaterThanOrEqOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(NotOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SingleBitAccessorNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AndOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(OrOpNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ProcedureDeclarationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(VariableDeclarationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(identifierDclNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(identifierDclAssignNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(identifierArrayDcl1Node node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(identifierArrayDcl2Node node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArrayAccessorNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ObjectDelacartionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SingleObjectDeclarationNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArrayObjectDeclartionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassDeclarationNode node)
		{
			return Visit((Node)node);
		}
	}
}
