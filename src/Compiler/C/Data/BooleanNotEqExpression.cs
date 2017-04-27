using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanNotEqExpression : Compiler.C.Data.Node
	{
		public  BooleanNotEqExpression()
		{
		}

		public  BooleanNotEqExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanNotEqExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
