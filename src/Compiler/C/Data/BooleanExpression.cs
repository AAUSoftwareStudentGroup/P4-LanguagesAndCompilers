using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanExpression : Compiler.C.Data.Node
	{
		public  BooleanExpression()
		{
		}

		public  BooleanExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
