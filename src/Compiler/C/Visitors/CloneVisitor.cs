namespace Compiler.C.Visitors
{
	public class CloneVisitor : CVisitor<Compiler.C.Data.Node>
	{
		public override Compiler.C.Data.Node Visit(Compiler.C.Data.C node)
		{
			var clone = new Compiler.C.Data.C() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.GlobalDeclarations node)
		{
			var clone = new Compiler.C.Data.GlobalDeclarations() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.GlobalDeclaration node)
		{
			var clone = new Compiler.C.Data.GlobalDeclaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.FunctionPrototype node)
		{
			var clone = new Compiler.C.Data.FunctionPrototype() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Functions node)
		{
			var clone = new Compiler.C.Data.Functions() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Function node)
		{
			var clone = new Compiler.C.Data.Function() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Statement node)
		{
			var clone = new Compiler.C.Data.Statement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.CompoundStatement node)
		{
			var clone = new Compiler.C.Data.CompoundStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerDeclaration node)
		{
			var clone = new Compiler.C.Data.IntegerDeclaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerAssignment node)
		{
			var clone = new Compiler.C.Data.IntegerAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanDeclaration node)
		{
			var clone = new Compiler.C.Data.BooleanDeclaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanAssignment node)
		{
			var clone = new Compiler.C.Data.BooleanAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.DirectBitAssignment node)
		{
			var clone = new Compiler.C.Data.DirectBitAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IndirectBitAssignment node)
		{
			var clone = new Compiler.C.Data.IndirectBitAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.RegisterDeclaration node)
		{
			var clone = new Compiler.C.Data.RegisterDeclaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.RegisterAssignment node)
		{
			var clone = new Compiler.C.Data.RegisterAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.RegisterExpression node)
		{
			var clone = new Compiler.C.Data.RegisterExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.RegisterLiteral node)
		{
			var clone = new Compiler.C.Data.RegisterLiteral() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.RegisterVariable node)
		{
			var clone = new Compiler.C.Data.RegisterVariable() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IfStatement node)
		{
			var clone = new Compiler.C.Data.IfStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.WhileStatement node)
		{
			var clone = new Compiler.C.Data.WhileStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerExpression node)
		{
			var clone = new Compiler.C.Data.IntegerExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerVariable node)
		{
			var clone = new Compiler.C.Data.IntegerVariable() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerParenthesisExpression node)
		{
			var clone = new Compiler.C.Data.IntegerParenthesisExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.AddExpression node)
		{
			var clone = new Compiler.C.Data.AddExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.SubExpression node)
		{
			var clone = new Compiler.C.Data.SubExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.MulExpression node)
		{
			var clone = new Compiler.C.Data.MulExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.DivExpression node)
		{
			var clone = new Compiler.C.Data.DivExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanExpression node)
		{
			var clone = new Compiler.C.Data.BooleanExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanVariable node)
		{
			var clone = new Compiler.C.Data.BooleanVariable() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.DirectBitValue node)
		{
			var clone = new Compiler.C.Data.DirectBitValue() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IndirectBitValue node)
		{
			var clone = new Compiler.C.Data.IndirectBitValue() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanParenthesisExpression node)
		{
			var clone = new Compiler.C.Data.BooleanParenthesisExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerEqExpression node)
		{
			var clone = new Compiler.C.Data.IntegerEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanEqExpression node)
		{
			var clone = new Compiler.C.Data.BooleanEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.LessThanExpression node)
		{
			var clone = new Compiler.C.Data.LessThanExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.GreaterThanExpression node)
		{
			var clone = new Compiler.C.Data.GreaterThanExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.NotExpression node)
		{
			var clone = new Compiler.C.Data.NotExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.AndExpression node)
		{
			var clone = new Compiler.C.Data.AndExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.OrExpression node)
		{
			var clone = new Compiler.C.Data.OrExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Token node)
		{
			return new Compiler.C.Data.Token() { Name = node.Name, Value = node.Value, Row = node.Row, Column = node.Column, IsPlaceholder = node.IsPlaceholder };
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Node node)
		{
			return null;
		}
	}
}