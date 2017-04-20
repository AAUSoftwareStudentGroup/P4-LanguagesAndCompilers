using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerVariable : Compiler.AST.Data.Node
	{
		public  IntegerVariable()
		{
		}

		public  IntegerVariable(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
