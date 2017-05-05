using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class RegisterReturn : Compiler.AST.Data.Node
	{
		public  RegisterReturn()
		{
		}

		public  RegisterReturn(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterReturn";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
