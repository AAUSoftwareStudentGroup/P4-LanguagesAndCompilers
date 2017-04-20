using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class MulExpression : Compiler.AST.Data.Node
	{
		public  MulExpression()
		{
		}

		public  MulExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
