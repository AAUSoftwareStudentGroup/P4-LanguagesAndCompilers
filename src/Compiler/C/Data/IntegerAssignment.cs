using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerAssignment : Compiler.C.Data.Node
	{
		public  IntegerAssignment()
		{
		}

		public  IntegerAssignment(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerAssignment";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
