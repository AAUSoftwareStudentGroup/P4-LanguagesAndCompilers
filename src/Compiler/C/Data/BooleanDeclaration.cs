using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanDeclaration : Compiler.C.Data.Node
	{
		public  BooleanDeclaration()
		{
			Id = NextId;
		}

		public  BooleanDeclaration(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "BooleanDeclaration";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
