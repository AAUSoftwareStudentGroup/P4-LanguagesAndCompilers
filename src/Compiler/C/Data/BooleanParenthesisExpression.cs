using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanParenthesisExpression : Compiler.C.Data.Node
	{
		public  BooleanParenthesisExpression()
		{
		}

		public  BooleanParenthesisExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanParenthesisExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
