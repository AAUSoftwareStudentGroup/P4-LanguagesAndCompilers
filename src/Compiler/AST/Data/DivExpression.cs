using Compiler.AST.Visitors;
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
			Name = "DivExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
