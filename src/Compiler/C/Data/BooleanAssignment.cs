using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanAssignment : Compiler.C.Data.Node
	{
		public  BooleanAssignment()
		{
		}

		public  BooleanAssignment(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanAssignment";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
