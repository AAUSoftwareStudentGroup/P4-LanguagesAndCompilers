using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class MulExpression : Compiler.C.Data.Node
	{
		public  MulExpression()
		{
		}

		public  MulExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "MulExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
