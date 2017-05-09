using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanArrayDeclaration : Compiler.AST.Data.Node
	{
		public  BooleanArrayDeclaration()
		{
		}

		public  BooleanArrayDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanArrayDeclaration";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
