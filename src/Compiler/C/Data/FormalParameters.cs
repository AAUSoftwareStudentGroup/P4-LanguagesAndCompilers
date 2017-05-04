using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class FormalParameters : Compiler.C.Data.Node
	{
		public  FormalParameters()
		{
		}

		public  FormalParameters(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "FormalParameters";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
