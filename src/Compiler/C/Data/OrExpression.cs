using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class OrExpression : Compiler.C.Data.Node
	{
		public  OrExpression()
		{
		}

		public  OrExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "OrExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
