using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class CompoundDeclaration : Compiler.C.Data.Node
	{
		public  CompoundDeclaration()
		{
		}

		public  CompoundDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "CompoundDeclaration";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
