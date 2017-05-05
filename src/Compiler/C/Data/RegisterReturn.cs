using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterReturn : Compiler.C.Data.Node
	{
		public  RegisterReturn()
		{
		}

		public  RegisterReturn(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterReturn";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
