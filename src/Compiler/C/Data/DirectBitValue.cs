using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class DirectBitValue : Compiler.C.Data.Node
	{
		public  DirectBitValue()
		{
		}

		public  DirectBitValue(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "DirectBitValue";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
