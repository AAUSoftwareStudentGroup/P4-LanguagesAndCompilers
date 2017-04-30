namespace Compiler.Parsing.Visitors
{
	public abstract class ProgramVisitor<T> 
	{
		public virtual T Visit(Compiler.Parsing.Data.Program node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.GlobalStatements node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.GlobalStatementsP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.GlobalStatement node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.Interrupt node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.Statements node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.StatementsP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.Statement node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.IdentifierDeclaration node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.RegisterStatement node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.RegisterType node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.RegisterOperation node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.Initialization node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.Assignment node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.BitSelector node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.IfStatement node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.WhileStatement node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.ForStatement node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.IntType node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.BooleanType node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.Expression node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.OrExpression node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.OrExpressionP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.AndExpression node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.AndExpressionP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.EqExpression node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.EqExpressionP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.RelationalExpression node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.RelationalExpressionP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.AddSubExpression node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.AddSubExpressionP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.MulDivExpression node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.MulDivExpressionP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.PowExpression node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.PowExpressionP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.PrimaryExpression node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.Token node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}
		public abstract T Visit(Compiler.Parsing.Data.Node node);
	}
}
