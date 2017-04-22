using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanVariable : Compiler.AST.Data.Node
	{
		public  BooleanVariable()
		{
		}

		public  BooleanVariable(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanVariable";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
