using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanVariable : Compiler.AST.Data.Node
	{
		public  BooleanVariable()
		{
		}

		public  BooleanVariable(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
