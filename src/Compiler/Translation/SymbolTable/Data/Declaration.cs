using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Declaration : Compiler.Translation.SymbolTable.Data.Node
	{
		public  Declaration()
		{
		}

		public  Declaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
