using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class GlobalStatement : Compiler.C.Data.Node
	{
		public  GlobalStatement()
		{
		}

		public  GlobalStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "GlobalStatement";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
