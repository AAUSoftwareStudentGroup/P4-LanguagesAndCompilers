using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerArray : Compiler.C.Data.Node
	{
		public  IntegerArray()
		{
		}

		public  IntegerArray(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerArray";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
