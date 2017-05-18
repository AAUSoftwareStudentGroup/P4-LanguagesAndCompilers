using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class BooleanType : Compiler.Translation.SymbolTable.Data.Node
	{
		public  BooleanType()
		{
			Id = NextId;
		}

		public  BooleanType(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "BooleanType";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
