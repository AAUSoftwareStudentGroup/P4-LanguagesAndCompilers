using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanVariable : Compiler.C.Data.Node
	{
		public  BooleanVariable()
		{
		}

		public  BooleanVariable(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanVariable";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
