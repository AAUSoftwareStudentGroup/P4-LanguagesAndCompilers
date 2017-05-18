using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class GreaterThanOrEqExpression : Compiler.AST.Data.Node
	{
		public  GreaterThanOrEqExpression()
		{
			Id = NextId;
		}

		public  GreaterThanOrEqExpression(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "GreaterThanOrEqExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
