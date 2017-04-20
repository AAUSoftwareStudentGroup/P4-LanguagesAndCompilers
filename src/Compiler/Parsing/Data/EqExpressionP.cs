using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class EqExpressionP : Compiler.Parsing.Data.Node
	{
		public  EqExpressionP()
		{
		}

		public  EqExpressionP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
