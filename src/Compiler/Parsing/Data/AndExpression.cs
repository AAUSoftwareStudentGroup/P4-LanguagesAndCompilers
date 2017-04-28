using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class AndExpression : Compiler.Parsing.Data.Node
	{
		public  AndExpression()
		{
		}

		public  AndExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "AndExpression";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
