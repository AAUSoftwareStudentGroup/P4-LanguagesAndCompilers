using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Variable : Compiler.Translation.SymbolTable.Data.Node
	{
		public  Variable()
		{
		}

		public  Variable(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Variable";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}