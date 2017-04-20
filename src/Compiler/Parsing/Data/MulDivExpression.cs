using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class MulDivExpression : Compiler.Parsing.Data.Node
	{
		public  MulDivExpression()
		{
		}

		public  MulDivExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
