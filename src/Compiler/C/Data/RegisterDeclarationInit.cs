using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterDeclarationInit : Compiler.C.Data.Node
	{
		public  RegisterDeclarationInit()
		{
			Id = NextId;
		}

		public  RegisterDeclarationInit(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "RegisterDeclarationInit";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
