using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class EqExpression : Compiler.Parsing.Data.Node
	{
		public  EqExpression()
		{
		}

		public  EqExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
