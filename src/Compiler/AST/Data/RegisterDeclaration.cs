using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class RegisterDeclaration : Compiler.AST.Data.Node
	{
		public  RegisterDeclaration()
		{
		}

		public  RegisterDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterDeclaration";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
