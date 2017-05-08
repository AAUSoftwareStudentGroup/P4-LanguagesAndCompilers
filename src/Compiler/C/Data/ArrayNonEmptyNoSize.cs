using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class ArrayNonEmptyNoSize : Compiler.C.Data.Node
	{
		public  ArrayNonEmptyNoSize()
		{
		}

		public  ArrayNonEmptyNoSize(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ArrayNonEmptyNoSize";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
