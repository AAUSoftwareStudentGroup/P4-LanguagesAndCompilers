using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class RegisterArrayDeclaration : Compiler.AST.Data.Node
	{
		public  RegisterArrayDeclaration()
		{
		}

		public  RegisterArrayDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterArrayDeclaration";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
