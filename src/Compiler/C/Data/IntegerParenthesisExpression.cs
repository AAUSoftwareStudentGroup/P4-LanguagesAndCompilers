using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerParenthesisExpression : Compiler.C.Data.Node
	{
		public  IntegerParenthesisExpression()
		{
			Id = NextId;
		}

		public  IntegerParenthesisExpression(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "IntegerParenthesisExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
