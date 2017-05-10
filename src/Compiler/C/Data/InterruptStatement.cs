using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class InterruptStatement : Compiler.C.Data.Node
	{
		public  InterruptStatement()
		{
		}

		public  InterruptStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "InterruptStatement";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
