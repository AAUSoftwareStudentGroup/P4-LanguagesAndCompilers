using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class DivExpression : Compiler.C.Data.Node
	{
		public  DivExpression()
		{
		}

		public  DivExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "DivExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
