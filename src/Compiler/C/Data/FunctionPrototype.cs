using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class FunctionPrototype : Compiler.C.Data.Node
	{
		public  FunctionPrototype()
		{
		}

		public  FunctionPrototype(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "FunctionPrototype";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
