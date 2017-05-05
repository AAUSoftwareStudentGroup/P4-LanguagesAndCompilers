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

		public virtual T Visit(Compiler.Parsing.Data.Definition node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.ReturnStatement node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.FormalParameters node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.FormalParametersP node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.FormalParameter node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.Type node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.IdentifierStatement node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.IdentifierStatementP node)
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

		public virtual T Visit(Compiler.Parsing.Data.ElseStatement node)
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

		public virtual T Visit(Compiler.Parsing.Data.IdentifierOperation node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.ActualParameters node)
		{
			return Visit((Compiler.Parsing.Data.Node)node);
		}

		public virtual T Visit(Compiler.Parsing.Data.ActualParametersP node)
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
