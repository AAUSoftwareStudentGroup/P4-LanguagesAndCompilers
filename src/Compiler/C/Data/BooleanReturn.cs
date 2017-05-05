using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanReturn : Compiler.C.Data.Node
	{
		public  BooleanReturn()
		{
		}

		public  BooleanReturn(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanReturn";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
