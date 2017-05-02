namespace Compiler.AST.Visitors
{
	public class CloneVisitor : ASTVisitor<Compiler.AST.Data.Node>
	{
		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.AST node)
		{
			var clone = new Compiler.AST.Data.AST() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.GlobalStatement node)
		{
			var clone = new Compiler.AST.Data.GlobalStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.Interrupt node)
		{
			var clone = new Compiler.AST.Data.Interrupt() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.Function node)
		{
			var clone = new Compiler.AST.Data.Function() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.Type node)
		{
			var clone = new Compiler.AST.Data.Type() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.FormalParameter node)
		{
			var clone = new Compiler.AST.Data.FormalParameter() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.CompoundFormalParameter node)
		{
			var clone = new Compiler.AST.Data.CompoundFormalParameter() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.CompoundGlobalStatement node)
		{
			var clone = new Compiler.AST.Data.CompoundGlobalStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.Statement node)
		{
			var clone = new Compiler.AST.Data.Statement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.CompoundStatement node)
		{
			var clone = new Compiler.AST.Data.CompoundStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IntegerDeclaration node)
		{
			var clone = new Compiler.AST.Data.IntegerDeclaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IntegerDeclarationInit node)
		{
			var clone = new Compiler.AST.Data.IntegerDeclarationInit() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IntegerAssignment node)
		{
			var clone = new Compiler.AST.Data.IntegerAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.BooleanDeclaration node)
		{
			var clone = new Compiler.AST.Data.BooleanDeclaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.BooleanDeclarationInit node)
		{
			var clone = new Compiler.AST.Data.BooleanDeclarationInit() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.BooleanType node)
		{
			var clone = new Compiler.AST.Data.BooleanType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.BooleanAssignment node)
		{
			var clone = new Compiler.AST.Data.BooleanAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.DirectBitAssignment node)
		{
			var clone = new Compiler.AST.Data.DirectBitAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IndirectBitAssignment node)
		{
			var clone = new Compiler.AST.Data.IndirectBitAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.RegisterDeclaration node)
		{
			var clone = new Compiler.AST.Data.RegisterDeclaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.RegisterDeclarationInit node)
		{
			var clone = new Compiler.AST.Data.RegisterDeclarationInit() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.RegisterAssignment node)
		{
			var clone = new Compiler.AST.Data.RegisterAssignment() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.RegisterExpression node)
		{
			var clone = new Compiler.AST.Data.RegisterExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.RegisterLiteral node)
		{
			var clone = new Compiler.AST.Data.RegisterLiteral() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.RegisterVariable node)
		{
			var clone = new Compiler.AST.Data.RegisterVariable() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IfStatement node)
		{
			var clone = new Compiler.AST.Data.IfStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IfElseStatement node)
		{
			var clone = new Compiler.AST.Data.IfElseStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.WhileStatement node)
		{
			var clone = new Compiler.AST.Data.WhileStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.ForStatement node)
		{
			var clone = new Compiler.AST.Data.ForStatement() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IntType node)
		{
			var clone = new Compiler.AST.Data.IntType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IntegerExpression node)
		{
			var clone = new Compiler.AST.Data.IntegerExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IntegerVariable node)
		{
			var clone = new Compiler.AST.Data.IntegerVariable() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IntegerParenthesisExpression node)
		{
			var clone = new Compiler.AST.Data.IntegerParenthesisExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.AddExpression node)
		{
			var clone = new Compiler.AST.Data.AddExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.SubExpression node)
		{
			var clone = new Compiler.AST.Data.SubExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.MulExpression node)
		{
			var clone = new Compiler.AST.Data.MulExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.DivExpression node)
		{
			var clone = new Compiler.AST.Data.DivExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.ModExpression node)
		{
			var clone = new Compiler.AST.Data.ModExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.PowExpression node)
		{
			var clone = new Compiler.AST.Data.PowExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.BooleanExpression node)
		{
			var clone = new Compiler.AST.Data.BooleanExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.BooleanVariable node)
		{
			var clone = new Compiler.AST.Data.BooleanVariable() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.DirectBitValue node)
		{
			var clone = new Compiler.AST.Data.DirectBitValue() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.RegisterType node)
		{
			var clone = new Compiler.AST.Data.RegisterType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IndirectBitValue node)
		{
			var clone = new Compiler.AST.Data.IndirectBitValue() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.BooleanParenthesisExpression node)
		{
			var clone = new Compiler.AST.Data.BooleanParenthesisExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IntegerEqExpression node)
		{
			var clone = new Compiler.AST.Data.IntegerEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.BooleanEqExpression node)
		{
			var clone = new Compiler.AST.Data.BooleanEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.IntegerNotEqExpression node)
		{
			var clone = new Compiler.AST.Data.IntegerNotEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.BooleanNotEqExpression node)
		{
			var clone = new Compiler.AST.Data.BooleanNotEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.LessThanExpression node)
		{
			var clone = new Compiler.AST.Data.LessThanExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.GreaterThanExpression node)
		{
			var clone = new Compiler.AST.Data.GreaterThanExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.LessThanOrEqExpression node)
		{
			var clone = new Compiler.AST.Data.LessThanOrEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.GreaterThanOrEqExpression node)
		{
			var clone = new Compiler.AST.Data.GreaterThanOrEqExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.NotExpression node)
		{
			var clone = new Compiler.AST.Data.NotExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.AndExpression node)
		{
			var clone = new Compiler.AST.Data.AndExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.OrExpression node)
		{
			var clone = new Compiler.AST.Data.OrExpression() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.Token node)
		{
			return new Compiler.AST.Data.Token() { Name = node.Name, Value = node.Value, Row = node.Row, Column = node.Column, IsPlaceholder = node.IsPlaceholder };
		}

		public override Compiler.AST.Data.Node Visit(Compiler.AST.Data.Node node)
		{
			return null;
		}
	}
}
