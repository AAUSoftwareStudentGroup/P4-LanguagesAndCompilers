using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerNotEqExpression : Compiler.AST.Data.Node
	{
		public  IntegerNotEqExpression()
		{
		}

		public  IntegerNotEqExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerNotEqExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
