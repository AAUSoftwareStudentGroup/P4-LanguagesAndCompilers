using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerDeclaration : Compiler.AST.Data.Node
	{
		public  IntegerDeclaration()
		{
		}

		public  IntegerDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerDeclaration";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
