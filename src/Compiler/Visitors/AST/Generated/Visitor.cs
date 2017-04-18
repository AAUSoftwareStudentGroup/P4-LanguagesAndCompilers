using Compiler.Shared;
using Compiler.Data.AST;

namespace Compiler.Visitors
{
	public abstract partial class Visitor<T> 
	{
		public virtual T Visit(ProgramNode node)
		{
			return Visit((Node)node);
		}

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

		public virtual T Visit(IdentifierDclNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IdentifierDclAssignNode node)
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

		public virtual T Visit(CompoundScopedLevelStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IfStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IfElseIfStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IfElseStatementNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ExpressionNode node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(RegisterExpressionNode node)
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

		public virtual T Visit(ReturnExpressionNode node)
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
	}
}
