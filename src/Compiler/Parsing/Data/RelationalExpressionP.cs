using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class RelationalExpressionP : Compiler.Parsing.Data.Node
	{
		public  RelationalExpressionP()
		{
		}

		public  RelationalExpressionP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
