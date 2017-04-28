using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class SubExpression : Compiler.C.Data.Node
	{
		public  SubExpression()
		{
		}

		public  SubExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "SubExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
