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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Declaration node)
		{
			var clone = new Compiler.C.Data.Declaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.CompoundDeclaration node)
		{
			var clone = new Compiler.C.Data.CompoundDeclaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Function node)
		{
			var clone = new Compiler.C.Data.Function() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.CompoundFunction node)
		{
			var clone = new Compiler.C.Data.CompoundFunction() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.FormalParameters node)
		{
			var clone = new Compiler.C.Data.FormalParameters() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.FormalParameter node)
		{
			var clone = new Compiler.C.Data.FormalParameter() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.CompoundFormalParameter node)
		{
			var clone = new Compiler.C.Data.CompoundFormalParameter() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Type node)
		{
			var clone = new Compiler.C.Data.Type() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerDeclarationInit node)
		{
			var clone = new Compiler.C.Data.IntegerDeclarationInit() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanDeclarationInit node)
		{
			var clone = new Compiler.C.Data.BooleanDeclarationInit() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanType node)
		{
			var clone = new Compiler.C.Data.BooleanType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.RegisterDeclarationInit node)
		{
			var clone = new Compiler.C.Data.RegisterDeclarationInit() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.RegisterType node)
		{
			var clone = new Compiler.C.Data.RegisterType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IfStatement node)
		{
			var clone = new Compiler.C.Data.IfStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IfElseStatement node)
		{
			var clone = new Compiler.C.Data.IfElseStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.ForStatement node)
		{
			var clone = new Compiler.C.Data.ForStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Call node)
		{
			var clone = new Compiler.C.Data.Call() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerReturn node)
		{
			var clone = new Compiler.C.Data.IntegerReturn() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanReturn node)
		{
			var clone = new Compiler.C.Data.BooleanReturn() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.RegisterReturn node)
		{
			var clone = new Compiler.C.Data.RegisterReturn() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.ExpressionList node)
		{
			var clone = new Compiler.C.Data.ExpressionList() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.ExpressionListArgs node)
		{
			var clone = new Compiler.C.Data.ExpressionListArgs() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntType node)
		{
			var clone = new Compiler.C.Data.IntType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.ModExpression node)
		{
			var clone = new Compiler.C.Data.ModExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.PowExpression node)
		{
			var clone = new Compiler.C.Data.PowExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerNotEqExpression node)
		{
			var clone = new Compiler.C.Data.IntegerNotEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanNotEqExpression node)
		{
			var clone = new Compiler.C.Data.BooleanNotEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.LessThanOrEqExpression node)
		{
			var clone = new Compiler.C.Data.LessThanOrEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.GreaterThanOrEqExpression node)
		{
			var clone = new Compiler.C.Data.GreaterThanOrEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.ArrayEmpty node)
		{
			var clone = new Compiler.C.Data.ArrayEmpty() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.ArrayNonEmptyNoSize node)
		{
			var clone = new Compiler.C.Data.ArrayNonEmptyNoSize() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.Expressions node)
		{
			var clone = new Compiler.C.Data.Expressions() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntExpressions node)
		{
			var clone = new Compiler.C.Data.IntExpressions() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BoolExpressions node)
		{
			var clone = new Compiler.C.Data.BoolExpressions() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.IntegerList node)
		{
			var clone = new Compiler.C.Data.IntegerList() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.C.Data.Node Visit(Compiler.C.Data.BooleanList node)
		{
			var clone = new Compiler.C.Data.BooleanList() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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
