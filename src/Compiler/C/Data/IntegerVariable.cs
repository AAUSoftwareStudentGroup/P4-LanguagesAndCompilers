using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerVariable : Compiler.C.Data.Node
	{
		public  IntegerVariable()
		{
		}

		public  IntegerVariable(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerVariable";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
