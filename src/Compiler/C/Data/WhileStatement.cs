using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class WhileStatement : Compiler.C.Data.Node
	{
		public  WhileStatement()
		{
		}

		public  WhileStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "WhileStatement";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
