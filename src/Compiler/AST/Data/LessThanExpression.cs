using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class LessThanExpression : Compiler.AST.Data.Node
	{
		public  LessThanExpression()
		{
		}

		public  LessThanExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "LessThanExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
