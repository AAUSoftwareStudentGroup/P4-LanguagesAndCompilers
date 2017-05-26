using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class RegisterEqExpression : Compiler.AST.Data.Node
	{
		public  RegisterEqExpression()
		{
			Id = NextId;
		}

		public  RegisterEqExpression(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "RegisterEqExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
