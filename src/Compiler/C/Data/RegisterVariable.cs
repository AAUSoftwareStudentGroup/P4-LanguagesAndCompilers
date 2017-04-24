using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterVariable : Compiler.C.Data.Node
	{
		public  RegisterVariable()
		{
		}

		public  RegisterVariable(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterVariable";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
