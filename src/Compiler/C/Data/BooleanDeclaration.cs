using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanDeclaration : Compiler.C.Data.Node
	{
		public  BooleanDeclaration()
		{
		}

		public  BooleanDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanDeclaration";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
