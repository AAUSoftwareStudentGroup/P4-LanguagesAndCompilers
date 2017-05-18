using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class ReturnType : Compiler.Translation.SymbolTable.Data.Node
	{
		public  ReturnType()
		{
			Id = NextId;
		}

		public  ReturnType(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "ReturnType";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
