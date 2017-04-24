using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IndirectBitAssignment : Compiler.C.Data.Node
	{
		public  IndirectBitAssignment()
		{
		}

		public  IndirectBitAssignment(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IndirectBitAssignment";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
