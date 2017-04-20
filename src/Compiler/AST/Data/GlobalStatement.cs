using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class GlobalStatement : Compiler.AST.Data.Node
	{
		public  GlobalStatement()
		{
		}

		public  GlobalStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
