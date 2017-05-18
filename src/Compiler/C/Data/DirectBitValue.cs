using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class DirectBitValue : Compiler.C.Data.Node
	{
		public  DirectBitValue()
		{
			Id = NextId;
		}

		public  DirectBitValue(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "DirectBitValue";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
