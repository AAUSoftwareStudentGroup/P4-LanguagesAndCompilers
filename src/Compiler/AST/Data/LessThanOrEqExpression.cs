using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class LessThanOrEqExpression : Compiler.AST.Data.Node
	{
		public  LessThanOrEqExpression()
		{
			Id = NextId;
		}

		public  LessThanOrEqExpression(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "LessThanOrEqExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
