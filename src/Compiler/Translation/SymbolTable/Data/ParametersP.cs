using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class ParametersP : Compiler.Translation.SymbolTable.Data.Node
	{
		public  ParametersP()
		{
		}

		public  ParametersP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ParametersP";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
