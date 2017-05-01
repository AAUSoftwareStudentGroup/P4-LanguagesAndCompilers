using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterDeclarationInit : Compiler.C.Data.Node
	{
		public  RegisterDeclarationInit()
		{
		}

		public  RegisterDeclarationInit(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterDeclarationInit";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
