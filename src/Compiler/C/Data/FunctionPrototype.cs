using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class FunctionPrototype : Compiler.C.Data.Node
	{
		public  FunctionPrototype()
		{
			Id = NextId;
		}

		public  FunctionPrototype(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "FunctionPrototype";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
