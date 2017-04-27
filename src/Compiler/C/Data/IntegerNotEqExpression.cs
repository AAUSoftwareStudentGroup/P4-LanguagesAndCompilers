using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerNotEqExpression : Compiler.C.Data.Node
	{
		public  IntegerNotEqExpression()
		{
		}

		public  IntegerNotEqExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerNotEqExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
