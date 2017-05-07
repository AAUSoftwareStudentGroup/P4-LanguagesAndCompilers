namespace Compiler.Parsing.Visitors
{
	public class CloneVisitor : ProgramVisitor<Compiler.Parsing.Data.Node>
	{
		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Program node)
		{
			var clone = new Compiler.Parsing.Data.Program() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.GlobalStatements node)
		{
			var clone = new Compiler.Parsing.Data.GlobalStatements() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.GlobalStatement node)
		{
			var clone = new Compiler.Parsing.Data.GlobalStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Interrupt node)
		{
			var clone = new Compiler.Parsing.Data.Interrupt() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Statements node)
		{
			var clone = new Compiler.Parsing.Data.Statements() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Statement node)
		{
			var clone = new Compiler.Parsing.Data.Statement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.IdentifierDeclaration node)
		{
			var clone = new Compiler.Parsing.Data.IdentifierDeclaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Array node)
		{
			var clone = new Compiler.Parsing.Data.Array() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.ArrayP node)
		{
			var clone = new Compiler.Parsing.Data.ArrayP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.RegisterStatement node)
		{
			var clone = new Compiler.Parsing.Data.RegisterStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.RegisterType node)
		{
			var clone = new Compiler.Parsing.Data.RegisterType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.RegisterOperation node)
		{
			var clone = new Compiler.Parsing.Data.RegisterOperation() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Definition node)
		{
			var clone = new Compiler.Parsing.Data.Definition() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.DefinitionAssign node)
		{
			var clone = new Compiler.Parsing.Data.DefinitionAssign() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.ReturnStatement node)
		{
			var clone = new Compiler.Parsing.Data.ReturnStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.FormalParameters node)
		{
			var clone = new Compiler.Parsing.Data.FormalParameters() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.FormalParametersP node)
		{
			var clone = new Compiler.Parsing.Data.FormalParametersP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.FormalParameter node)
		{
			var clone = new Compiler.Parsing.Data.FormalParameter() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Type node)
		{
			var clone = new Compiler.Parsing.Data.Type() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.IdentifierStatement node)
		{
			var clone = new Compiler.Parsing.Data.IdentifierStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.IdentifierStatementP node)
		{
			var clone = new Compiler.Parsing.Data.IdentifierStatementP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.BitSelector node)
		{
			var clone = new Compiler.Parsing.Data.BitSelector() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.IfStatement node)
		{
			var clone = new Compiler.Parsing.Data.IfStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.ElseStatement node)
		{
			var clone = new Compiler.Parsing.Data.ElseStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.WhileStatement node)
		{
			var clone = new Compiler.Parsing.Data.WhileStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.ForStatement node)
		{
			var clone = new Compiler.Parsing.Data.ForStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.IntType node)
		{
			var clone = new Compiler.Parsing.Data.IntType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.BooleanType node)
		{
			var clone = new Compiler.Parsing.Data.BooleanType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Expression node)
		{
			var clone = new Compiler.Parsing.Data.Expression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.OrExpression node)
		{
			var clone = new Compiler.Parsing.Data.OrExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.OrExpressionP node)
		{
			var clone = new Compiler.Parsing.Data.OrExpressionP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.AndExpression node)
		{
			var clone = new Compiler.Parsing.Data.AndExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.AndExpressionP node)
		{
			var clone = new Compiler.Parsing.Data.AndExpressionP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.EqExpression node)
		{
			var clone = new Compiler.Parsing.Data.EqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.EqExpressionP node)
		{
			var clone = new Compiler.Parsing.Data.EqExpressionP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.RelationalExpression node)
		{
			var clone = new Compiler.Parsing.Data.RelationalExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.RelationalExpressionP node)
		{
			var clone = new Compiler.Parsing.Data.RelationalExpressionP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.AddSubExpression node)
		{
			var clone = new Compiler.Parsing.Data.AddSubExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.AddSubExpressionP node)
		{
			var clone = new Compiler.Parsing.Data.AddSubExpressionP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.MulDivExpression node)
		{
			var clone = new Compiler.Parsing.Data.MulDivExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.MulDivExpressionP node)
		{
			var clone = new Compiler.Parsing.Data.MulDivExpressionP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.PowExpression node)
		{
			var clone = new Compiler.Parsing.Data.PowExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.PowExpressionP node)
		{
			var clone = new Compiler.Parsing.Data.PowExpressionP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.PrimaryExpression node)
		{
			var clone = new Compiler.Parsing.Data.PrimaryExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.IdentifierOperation node)
		{
			var clone = new Compiler.Parsing.Data.IdentifierOperation() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.ExpressionList node)
		{
			var clone = new Compiler.Parsing.Data.ExpressionList() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.ExpressionListP node)
		{
			var clone = new Compiler.Parsing.Data.ExpressionListP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Token node)
		{
			return new Compiler.Parsing.Data.Token() { Name = node.Name, Value = node.Value, Row = node.Row, Column = node.Column, IsPlaceholder = node.IsPlaceholder };
		}

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Node node)
		{
			return null;
		}
	}
}
