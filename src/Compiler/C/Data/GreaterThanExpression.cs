using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class GreaterThanExpression : Compiler.C.Data.Node
	{
		public  GreaterThanExpression()
		{
		}

		public  GreaterThanExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "GreaterThanExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
