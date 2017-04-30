using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class RegisterDeclarationInit : Compiler.AST.Data.Node
	{
		public  RegisterDeclarationInit()
		{
		}

		public  RegisterDeclarationInit(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterDeclarationInit";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
