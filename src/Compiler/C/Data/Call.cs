using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class Call : Compiler.C.Data.Node
	{
		public  Call()
		{
		}

		public  Call(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Call";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
