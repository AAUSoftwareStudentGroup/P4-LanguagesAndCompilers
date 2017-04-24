using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterDeclaration : Compiler.C.Data.Node
	{
		public  RegisterDeclaration()
		{
		}

		public  RegisterDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterDeclaration";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
