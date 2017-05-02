using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Parameter : Compiler.Translation.SymbolTable.Data.Node
	{
		public  Parameter()
		{
		}

		public  Parameter(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Parameter";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
