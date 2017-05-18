using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class RegisterAssignment : Compiler.AST.Data.Node
	{
		public  RegisterAssignment()
		{
			Id = NextId;
		}

		public  RegisterAssignment(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "RegisterAssignment";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
