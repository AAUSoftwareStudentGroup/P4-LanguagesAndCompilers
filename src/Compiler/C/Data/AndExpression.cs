using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class AndExpression : Compiler.C.Data.Node
	{
		public  AndExpression()
		{
		}

		public  AndExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "AndExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
