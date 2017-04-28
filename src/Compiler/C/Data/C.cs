using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class C : Compiler.C.Data.Node
	{
		public  C()
		{
		}

		public  C(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "C";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
