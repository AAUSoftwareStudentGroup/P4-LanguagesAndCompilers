using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanAssignment : Compiler.AST.Data.Node
	{
		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
