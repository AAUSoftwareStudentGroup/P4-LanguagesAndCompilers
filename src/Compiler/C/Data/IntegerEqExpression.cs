using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerEqExpression : Compiler.C.Data.Node
	{
		public  IntegerEqExpression()
		{
		}

		public  IntegerEqExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerEqExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
