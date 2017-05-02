using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class CompoundParameter : Compiler.Translation.SymbolTable.Data.Node
	{
		public  CompoundParameter()
		{
		}

		public  CompoundParameter(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "CompoundParameter";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
