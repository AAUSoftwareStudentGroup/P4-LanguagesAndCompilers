using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class ExpressionListArgs : Compiler.AST.Data.Node
	{
		public  ExpressionListArgs()
		{
		}

		public  ExpressionListArgs(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ExpressionListArgs";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
