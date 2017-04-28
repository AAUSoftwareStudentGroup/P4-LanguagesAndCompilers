using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class ForStatement : Compiler.C.Data.Node
	{
		public  ForStatement()
		{
		}

		public  ForStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ForStatement";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
