using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class GreaterThanOrEqExpression : Compiler.C.Data.Node
	{
		public  GreaterThanOrEqExpression()
		{
			Id = NextId;
		}

		public  GreaterThanOrEqExpression(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "GreaterThanOrEqExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
