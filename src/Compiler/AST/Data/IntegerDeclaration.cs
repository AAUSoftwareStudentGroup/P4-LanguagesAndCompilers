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
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
