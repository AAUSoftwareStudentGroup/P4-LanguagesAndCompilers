using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerExpressionListArgs : Compiler.C.Data.Node
	{
		public  IntegerExpressionListArgs()
		{
		}

		public  IntegerExpressionListArgs(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerExpressionListArgs";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
