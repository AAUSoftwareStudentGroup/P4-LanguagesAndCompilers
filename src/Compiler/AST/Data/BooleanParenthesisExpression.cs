using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanParenthesisExpression : Compiler.AST.Data.Node
	{
		public  BooleanParenthesisExpression()
		{
		}

		public  BooleanParenthesisExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
