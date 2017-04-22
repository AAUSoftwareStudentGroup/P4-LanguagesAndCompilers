using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class OrExpression : Compiler.Parsing.Data.Node
	{
		public  OrExpression()
		{
		}

		public  OrExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "OrExpression";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
