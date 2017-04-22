using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class NotExpression : Compiler.AST.Data.Node
	{
		public  NotExpression()
		{
		}

		public  NotExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "NotExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
