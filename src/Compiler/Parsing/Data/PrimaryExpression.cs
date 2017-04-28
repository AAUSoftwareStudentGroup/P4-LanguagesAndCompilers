using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class PrimaryExpression : Compiler.Parsing.Data.Node
	{
		public  PrimaryExpression()
		{
		}

		public  PrimaryExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "PrimaryExpression";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
