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

		public override Compiler.Translation.SymbolTable.Data.Node Visit(Compiler.Translation.SymbolTable.Data.Type node)
		{
			var clone = new Compiler.Translation.SymbolTable.Data.Type() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
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
