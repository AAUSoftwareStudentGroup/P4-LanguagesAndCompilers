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

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.GlobalStatementsP node)
		{
			var clone = new Compiler.Parsing.Data.GlobalStatementsP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.StatementsP node)
		{
			var clone = new Compiler.Parsing.Data.StatementsP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.RegisterStatement node)
		{
			var clone = new Compiler.Parsing.Data.RegisterStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.Parsing.Data.Node Visit(Compiler.Parsing.Data.Assignment node)
		{
			var clone = new Compiler.Parsing.Data.Assignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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
