using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class ParameterTypes : Compiler.Translation.SymbolTable.Data.Node
	{
		public  ParameterTypes()
		{
		}

		public  ParameterTypes(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ParameterTypes";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
