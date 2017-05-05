namespace Compiler.Translation.SymbolTable.Visitors
{
	public class CloneVisitor : SymbolTableVisitor<Compiler.Translation.SymbolTable.Data.Node>
	{
		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.SymbolTable node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.SymbolTable() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Declarations node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.Declarations() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Declaration node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.Declaration() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Variable node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.Variable() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Function node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.Function() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.ReturnType node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.ReturnType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Parameters node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.Parameters() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.ParametersP node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.ParametersP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Parameter node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.Parameter() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Type node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.Type() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.ParameterTypes node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.ParameterTypes() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.IntType node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.IntType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.RegisterType node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.RegisterType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.BooleanType node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.BooleanType() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Token node)
		{
			return new Compiler.Translation.SymbolTable.Data.Token() { Name = node.Name, Value = node.Value, Row = node.Row, Column = node.Column, IsPlaceholder = node.IsPlaceholder };
		}

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Node node)
		{
			return null;
		}
	}
}
