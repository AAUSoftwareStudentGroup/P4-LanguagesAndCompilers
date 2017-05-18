using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class ExpressionListArgs : Compiler.AST.Data.Node
	{
		public  ExpressionListArgs()
		{
			Id = NextId;
		}

		public  ExpressionListArgs(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "ExpressionListArgs";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
