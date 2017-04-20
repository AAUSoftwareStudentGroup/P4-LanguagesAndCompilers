using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class AndExpression : Compiler.AST.Data.Node
	{
		public  AndExpression()
		{
		}

		public  AndExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
