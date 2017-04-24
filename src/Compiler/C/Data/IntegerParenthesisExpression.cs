using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerParenthesisExpression : Compiler.C.Data.Node
	{
		public  IntegerParenthesisExpression()
		{
		}

		public  IntegerParenthesisExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerParenthesisExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
