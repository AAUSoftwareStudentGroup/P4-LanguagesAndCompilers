namespace Compiler.C.Visitors
{
	public abstract class CVisitor<T> 
	{
		public virtual T Visit(Compiler.C.Data.C node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.Declaration node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.CompoundDeclaration node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.FunctionPrototype node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.Function node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.CompoundFunction node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.FormalParameters node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.FormalParameter node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.CompoundFormalParameter node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.Type node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.Statement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.CompoundStatement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerDeclaration node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerDeclarationInit node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerAssignment node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanDeclaration node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanDeclarationInit node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanType node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanAssignment node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.DirectBitAssignment node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IndirectBitAssignment node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.RegisterDeclaration node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.RegisterDeclarationInit node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.RegisterType node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.RegisterAssignment node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.RegisterExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.RegisterLiteral node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IfStatement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IfElseStatement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IfElseIfStatement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.WhileStatement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.ForStatement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.Call node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerReturn node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanReturn node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.RegisterReturn node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.EmptyReturn node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.InterruptStatement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.ExpressionList node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.ExpressionListArgs node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.CompoundArgs node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntType node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerParenthesisExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.AddExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.SubExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.MulExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.DivExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.ModExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.PowExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.DirectBitValue node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IndirectBitValue node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanParenthesisExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerEqExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanEqExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerNotEqExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanNotEqExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.LessThanExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.GreaterThanExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.LessThanOrEqExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.GreaterThanOrEqExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.NotExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.AndExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.OrExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.Expressions node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntExpressions node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BoolExpressions node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerList node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanList node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.Token node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}
		public abstract T Visit(Compiler.C.Data.Node node);
	}
}
