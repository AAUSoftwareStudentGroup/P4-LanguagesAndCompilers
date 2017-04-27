using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class GreaterThanOrEqExpression : Compiler.AST.Data.Node
	{
		public  GreaterThanOrEqExpression()
		{
		}

		public  GreaterThanOrEqExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "GreaterThanOrEqExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
