using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class Token : Compiler.Parsing.Data.Node
	{
		public string Value { get; set; }
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

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
