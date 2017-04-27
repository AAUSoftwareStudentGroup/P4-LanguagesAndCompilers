using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class PowExpression : Compiler.AST.Data.Node
	{
		public  PowExpression()
		{
		}

		public  PowExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "PowExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
