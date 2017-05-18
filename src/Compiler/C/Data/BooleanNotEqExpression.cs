using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanNotEqExpression : Compiler.C.Data.Node
	{
		public  BooleanNotEqExpression()
		{
			Id = NextId;
		}

		public  BooleanNotEqExpression(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "BooleanNotEqExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
