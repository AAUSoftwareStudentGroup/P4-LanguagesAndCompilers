namespace Compiler.AST.Visitors
{
	public abstract class ASTVisitor<T> 
	{
		public virtual T Visit(Compiler.AST.Data.AST node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.GlobalStatement node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.Interrupt node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.Function node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.FormalParameter node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.CompoundFormalParameter node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.CompoundGlobalStatement node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.Statement node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.CompoundStatement node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IntegerDeclaration node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IntegerDeclarationInit node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IntegerAssignment node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.BooleanDeclaration node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.BooleanDeclarationInit node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.BooleanType node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.BooleanAssignment node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.DirectBitAssignment node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IndirectBitAssignment node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.RegisterDeclaration node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.RegisterDeclarationInit node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.RegisterAssignment node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.RegisterExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.RegisterLiteral node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.RegisterVariable node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IfStatement node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IfElseStatement node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.WhileStatement node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.ForStatement node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IntType node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IntegerExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IntegerVariable node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IntegerParenthesisExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.AddExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.SubExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.MulExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.DivExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.ModExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.PowExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.BooleanExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.BooleanVariable node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.DirectBitValue node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.RegisterType node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IndirectBitValue node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.BooleanParenthesisExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IntegerEqExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.BooleanEqExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.IntegerNotEqExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.BooleanNotEqExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.LessThanExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.GreaterThanExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.LessThanOrEqExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.GreaterThanOrEqExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.NotExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.AndExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.OrExpression node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}

		public virtual T Visit(Compiler.AST.Data.Token node)
		{
			return Visit((Compiler.AST.Data.Node)node);
		}
		public abstract T Visit(Compiler.AST.Data.Node node);
	}
}
