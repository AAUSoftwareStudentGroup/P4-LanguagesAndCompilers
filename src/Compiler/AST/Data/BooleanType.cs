using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanType : Compiler.AST.Data.Node
	{
		public  BooleanType()
		{
		}

		public  BooleanType(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanType";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
