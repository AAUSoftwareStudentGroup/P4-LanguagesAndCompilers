using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class RegisterType : Compiler.Translation.SymbolTable.Data.Node
	{
		public  RegisterType()
		{
		}

		public  RegisterType(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterType";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
