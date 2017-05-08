using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class Expressions : Compiler.C.Data.Node
	{
		public  Expressions()
		{
		}

		public  Expressions(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Expressions";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
