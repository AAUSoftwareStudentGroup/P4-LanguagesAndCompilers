using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanList : Compiler.C.Data.Node
	{
		public  BooleanList()
		{
		}

		public  BooleanList(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanList";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
