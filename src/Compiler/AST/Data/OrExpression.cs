using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class OrExpression : Compiler.AST.Data.Node
	{
		public  OrExpression()
		{
		}

		public  OrExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
