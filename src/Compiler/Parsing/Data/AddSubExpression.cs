using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class AddSubExpression : Compiler.Parsing.Data.Node
	{
		public  AddSubExpression()
		{
		}

		public  AddSubExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
