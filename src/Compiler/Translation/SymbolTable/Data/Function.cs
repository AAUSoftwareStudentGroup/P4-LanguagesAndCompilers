using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Function : Compiler.Translation.SymbolTable.Data.Node
	{
		public  Function()
		{
		}

		public  Function(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Function";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
