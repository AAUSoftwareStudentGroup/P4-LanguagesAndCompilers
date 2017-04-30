using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntType : Compiler.AST.Data.Node
	{
		public  IntType()
		{
		}

		public  IntType(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntType";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
