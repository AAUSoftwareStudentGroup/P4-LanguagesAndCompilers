using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class LessThanOrEqExpression : Compiler.C.Data.Node
	{
		public  LessThanOrEqExpression()
		{
			Id = NextId;
		}

		public  LessThanOrEqExpression(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "LessThanOrEqExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
