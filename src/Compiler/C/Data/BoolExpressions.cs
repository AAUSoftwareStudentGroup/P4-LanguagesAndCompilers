using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BoolExpressions : Compiler.C.Data.Node
	{
		public  BoolExpressions()
		{
		}

		public  BoolExpressions(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BoolExpressions";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
