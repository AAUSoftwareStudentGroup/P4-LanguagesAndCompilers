using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Array : Compiler.Translation.SymbolTable.Data.Node
	{
		public  Array()
		{
		}

		public  Array(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Array";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
