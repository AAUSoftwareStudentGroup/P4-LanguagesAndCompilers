using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class ExpressionList : Compiler.AST.Data.Node
	{
		public  ExpressionList()
		{
		}

		public  ExpressionList(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ExpressionList";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
