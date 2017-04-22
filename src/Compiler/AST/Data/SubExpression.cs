using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class SubExpression : Compiler.AST.Data.Node
	{
		public  SubExpression()
		{
		}

		public  SubExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "SubExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
