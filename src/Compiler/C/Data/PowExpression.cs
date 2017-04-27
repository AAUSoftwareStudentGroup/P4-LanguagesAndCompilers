using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class PowExpression : Compiler.C.Data.Node
	{
		public  PowExpression()
		{
		}

		public  PowExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "PowExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
