using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanEqExpression : Compiler.AST.Data.Node
	{
		public  BooleanEqExpression()
		{
		}

		public  BooleanEqExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
