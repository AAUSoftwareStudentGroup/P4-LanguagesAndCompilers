using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class AddSubExpressionP : Compiler.Parsing.Data.Node
	{
		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
