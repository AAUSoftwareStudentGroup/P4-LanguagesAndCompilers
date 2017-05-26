using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class RegisterNotEqExpression : Compiler.AST.Data.Node
	{
		public  RegisterNotEqExpression()
		{
			Id = NextId;
		}

		public  RegisterNotEqExpression(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "RegisterNotEqExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
