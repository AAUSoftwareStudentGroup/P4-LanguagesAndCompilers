using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterDeclaration : Compiler.C.Data.Node
	{
		public  RegisterDeclaration()
		{
			Id = NextId;
		}

		public  RegisterDeclaration(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "RegisterDeclaration";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
