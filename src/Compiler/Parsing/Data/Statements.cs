using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class Statements : Compiler.Parsing.Data.Node
	{
		public  Statements()
		{
		}

		public  Statements(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
