using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Variable : Compiler.Translation.SymbolTable.Data.Node
	{
		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
