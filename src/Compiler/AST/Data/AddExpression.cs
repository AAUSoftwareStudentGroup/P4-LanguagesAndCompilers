using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class AddExpression : Compiler.AST.Data.Node
	{
		public  AddExpression()
		{
		}

		public  AddExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
