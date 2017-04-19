using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class Token : Compiler.Parsing.Data.Node
	{
		public string Value { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
