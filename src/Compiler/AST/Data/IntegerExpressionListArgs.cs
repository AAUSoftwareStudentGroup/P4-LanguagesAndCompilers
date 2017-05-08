using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerExpressionListArgs : Compiler.AST.Data.Node
	{
		public  IntegerExpressionListArgs()
		{
		}

		public  IntegerExpressionListArgs(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerExpressionListArgs";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
