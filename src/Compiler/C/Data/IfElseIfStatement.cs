using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IfElseIfStatement : Compiler.C.Data.Node
	{
		public  IfElseIfStatement()
		{
		}

		public  IfElseIfStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IfElseIfStatement";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
