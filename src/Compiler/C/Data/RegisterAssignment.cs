using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterAssignment : Compiler.C.Data.Node
	{
		public  RegisterAssignment()
		{
			Id = NextId;
		}

		public  RegisterAssignment(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "RegisterAssignment";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
