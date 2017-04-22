using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanExpression : Compiler.AST.Data.Node
	{
		public  BooleanExpression()
		{
		}

		public  BooleanExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
