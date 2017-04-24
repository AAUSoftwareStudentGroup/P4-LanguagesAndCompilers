using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class DirectBitAssignment : Compiler.C.Data.Node
	{
		public  DirectBitAssignment()
		{
		}

		public  DirectBitAssignment(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "DirectBitAssignment";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
