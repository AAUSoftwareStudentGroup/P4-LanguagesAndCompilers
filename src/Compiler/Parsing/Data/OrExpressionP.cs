using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class OrExpressionP : Compiler.Parsing.Data.Node
	{
		public  OrExpressionP()
		{
		}

		public  OrExpressionP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
