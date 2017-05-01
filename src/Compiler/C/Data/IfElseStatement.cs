using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IfElseStatement : Compiler.C.Data.Node
	{
		public  IfElseStatement()
		{
		}

		public  IfElseStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IfElseStatement";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
