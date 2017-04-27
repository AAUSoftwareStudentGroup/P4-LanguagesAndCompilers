namespace Compiler.C.Visitors
{
	public abstract class CVisitor<T> 
	{
		public virtual T Visit(Compiler.C.Data.C node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.GlobalDeclarations node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.GlobalDeclaration node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.FunctionPrototype node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.Functions node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.Function node)
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

		public virtual T Visit(Compiler.C.Data.IntegerAssignment node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanDeclaration node)
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

		public virtual T Visit(Compiler.C.Data.RegisterVariable node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IfStatement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.WhileStatement node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.IntegerVariable node)
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

		public virtual T Visit(Compiler.C.Data.BooleanExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.BooleanVariable node)
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

		public virtual T Visit(Compiler.C.Data.LessThanExpression node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}

		public virtual T Visit(Compiler.C.Data.GreaterThanExpression node)
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

		public virtual T Visit(Compiler.C.Data.Token node)
		{
			return Visit((Compiler.C.Data.Node)node);
		}
		public abstract T Visit(Compiler.C.Data.Node node);
	}
}