using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanNotEqExpression : Compiler.AST.Data.Node
	{
		public  BooleanNotEqExpression()
		{
		}

		public  BooleanNotEqExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanNotEqExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
