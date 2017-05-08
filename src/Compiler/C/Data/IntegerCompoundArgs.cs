using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerCompoundArgs : Compiler.C.Data.Node
	{
		public  IntegerCompoundArgs()
		{
		}

		public  IntegerCompoundArgs(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerCompoundArgs";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
