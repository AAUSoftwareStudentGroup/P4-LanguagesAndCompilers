using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ExpressionList : Compiler.Parsing.Data.Node
	{
		public  ExpressionList()
		{
		}

		public  ExpressionList(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ExpressionList";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
