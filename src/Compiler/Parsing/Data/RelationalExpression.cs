using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class RelationalExpression : Compiler.Parsing.Data.Node
	{
		public  RelationalExpression()
		{
		}

		public  RelationalExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RelationalExpression";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
