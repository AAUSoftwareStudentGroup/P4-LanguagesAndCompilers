using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class ArrayEmpty : Compiler.C.Data.Node
	{
		public  ArrayEmpty()
		{
		}

		public  ArrayEmpty(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ArrayEmpty";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
