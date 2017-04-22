using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class RegisterLiteral : Compiler.AST.Data.Node
	{
		public  RegisterLiteral()
		{
		}

		public  RegisterLiteral(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterLiteral";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
