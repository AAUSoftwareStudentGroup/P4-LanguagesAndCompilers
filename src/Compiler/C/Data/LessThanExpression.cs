using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class LessThanExpression : Compiler.C.Data.Node
	{
		public  LessThanExpression()
		{
		}

		public  LessThanExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "LessThanExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
