using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IndirectBitValue : Compiler.C.Data.Node
	{
		public  IndirectBitValue()
		{
			Id = NextId;
		}

		public  IndirectBitValue(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "IndirectBitValue";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
