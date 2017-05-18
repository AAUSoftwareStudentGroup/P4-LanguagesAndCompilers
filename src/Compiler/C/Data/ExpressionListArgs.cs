using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class ExpressionListArgs : Compiler.C.Data.Node
	{
		public  ExpressionListArgs()
		{
			Id = NextId;
		}

		public  ExpressionListArgs(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "ExpressionListArgs";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
