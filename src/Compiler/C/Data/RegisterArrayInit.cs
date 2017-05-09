using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterArrayInit : Compiler.C.Data.Node
	{
		public  RegisterArrayInit()
		{
		}

		public  RegisterArrayInit(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterArrayInit";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
