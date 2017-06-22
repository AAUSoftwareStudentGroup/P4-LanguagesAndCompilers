namespace Compiler.ASM.Visitors
{
	public class CloneVisitor : ASMVisitor<Compiler.ASM.Data.Node>
	{
		public override Compiler.ASM.Data.Node Visit(Compiler.ASM.Data.ASM node)
		{
			var clone = new Compiler.ASM.Data.ASM() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.ASM.Data.Node Visit(Compiler.ASM.Data.RegTable node)
		{
			var clone = new Compiler.ASM.Data.RegTable() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Compiler.ASM.Data.Node Visit(Compiler.ASM.Data.Token node)
		{
			return new Compiler.ASM.Data.Token() { Name = node.Name, Value = node.Value, FileName = node.FileName, Row = node.Row, Column = node.Column, IsPlaceholder = node.IsPlaceholder };
		}

		public override Compiler.ASM.Data.Node Visit(Compiler.ASM.Data.Node node)
		{
			return null;
		}
	}
}
