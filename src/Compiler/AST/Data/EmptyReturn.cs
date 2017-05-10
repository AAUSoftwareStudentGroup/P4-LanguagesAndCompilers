using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class EmptyReturn : Compiler.AST.Data.Node
	{
		public  EmptyReturn()
		{
		}

		public  EmptyReturn(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "EmptyReturn";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
