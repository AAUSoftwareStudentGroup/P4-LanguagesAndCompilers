using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanDeclaration : Compiler.AST.Data.Node
	{
		public  BooleanDeclaration()
		{
			Id = NextId;
		}

		public  BooleanDeclaration(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "BooleanDeclaration";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
