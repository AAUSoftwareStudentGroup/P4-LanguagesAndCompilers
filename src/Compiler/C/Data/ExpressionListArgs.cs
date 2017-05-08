using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class ExpressionListArgs : Compiler.C.Data.Node
	{
		public  ExpressionListArgs()
		{
		}

		public  ExpressionListArgs(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ExpressionListArgs";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
