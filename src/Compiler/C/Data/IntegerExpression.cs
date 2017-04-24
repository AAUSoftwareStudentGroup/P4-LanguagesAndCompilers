using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerExpression : Compiler.C.Data.Node
	{
		public  IntegerExpression()
		{
		}

		public  IntegerExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
