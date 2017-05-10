using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class EmptyReturn : Compiler.C.Data.Node
	{
		public  EmptyReturn()
		{
		}

		public  EmptyReturn(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "EmptyReturn";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
