using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class Functions : Compiler.C.Data.Node
	{
		public  Functions()
		{
		}

		public  Functions(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Functions";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
