using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterExpression : Compiler.C.Data.Node
	{
		public  RegisterExpression()
		{
		}

		public  RegisterExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
