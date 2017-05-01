using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Variables : Compiler.Translation.SymbolTable.Data.Node
	{
		public  Variables()
		{
		}

		public  Variables(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Variables";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
