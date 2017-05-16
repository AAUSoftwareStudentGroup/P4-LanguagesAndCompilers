using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class Token : Compiler.C.Data.Node
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

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
