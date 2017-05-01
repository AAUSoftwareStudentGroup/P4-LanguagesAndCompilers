using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class CompoundFunction : Compiler.C.Data.Node
	{
		public  CompoundFunction()
		{
		}

		public  CompoundFunction(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "CompoundFunction";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
