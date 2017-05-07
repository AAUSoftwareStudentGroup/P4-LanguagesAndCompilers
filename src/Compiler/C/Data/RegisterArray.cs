using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class RegisterArray : Compiler.C.Data.Node
	{
		public  RegisterArray()
		{
		}

		public  RegisterArray(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterArray";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
