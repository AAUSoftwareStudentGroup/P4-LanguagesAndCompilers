using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class ExpressionList : Compiler.C.Data.Node
	{
		public  ExpressionList()
		{
		}

		public  ExpressionList(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ExpressionList";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
