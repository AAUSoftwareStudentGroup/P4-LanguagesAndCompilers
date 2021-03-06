using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Parameters : Compiler.Translation.SymbolTable.Data.Node
	{
		public  Parameters()
		{
			Id = NextId;
		}

		public  Parameters(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "Parameters";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
