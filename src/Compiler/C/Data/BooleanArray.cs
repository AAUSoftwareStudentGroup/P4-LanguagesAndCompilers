using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanArray : Compiler.C.Data.Node
	{
		public  BooleanArray()
		{
		}

		public  BooleanArray(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanArray";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
