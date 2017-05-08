using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerArrayDeclaration : Compiler.AST.Data.Node
	{
		public  IntegerArrayDeclaration()
		{
		}

		public  IntegerArrayDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerArrayDeclaration";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
