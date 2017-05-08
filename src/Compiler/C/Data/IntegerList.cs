using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerList : Compiler.C.Data.Node
	{
		public  IntegerList()
		{
		}

		public  IntegerList(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerList";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
