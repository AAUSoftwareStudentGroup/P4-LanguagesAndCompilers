using Compiler.Translation.SymbolTable.Visitors;
using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class Token : Compiler.Translation.SymbolTable.Data.Node
	{
		public string Value { get; set; }
		public string FileName { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public  Token()
		{
		}

		public  Token(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Token";
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
