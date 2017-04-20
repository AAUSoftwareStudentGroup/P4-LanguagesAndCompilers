using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class DivExpression : Compiler.AST.Data.Node
	{
		public  DivExpression()
		{
		}

		public  DivExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
