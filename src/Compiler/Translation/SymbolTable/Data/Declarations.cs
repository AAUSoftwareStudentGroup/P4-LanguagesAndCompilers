using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Declarations : Compiler.Translation.SymbolTable.Data.Node
	{
		public  Declarations()
		{
		}

		public  Declarations(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Declarations";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
