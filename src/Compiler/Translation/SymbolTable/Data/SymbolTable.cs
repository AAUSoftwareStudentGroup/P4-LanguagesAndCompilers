using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class SymbolTable : Compiler.Translation.SymbolTable.Data.Node
	{
		public  SymbolTable()
		{
		}

		public  SymbolTable(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "SymbolTable";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
