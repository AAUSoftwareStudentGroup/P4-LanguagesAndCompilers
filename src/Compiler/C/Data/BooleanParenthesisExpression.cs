using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanParenthesisExpression : Compiler.C.Data.Node
	{
		public  BooleanParenthesisExpression()
		{
			Id = NextId;
		}

		public  BooleanParenthesisExpression(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "BooleanParenthesisExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
