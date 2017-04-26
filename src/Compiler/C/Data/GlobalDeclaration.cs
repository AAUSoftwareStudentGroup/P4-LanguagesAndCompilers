using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class GlobalDeclaration : Compiler.C.Data.Node
	{
		public  GlobalDeclaration()
		{
		}

		public  GlobalDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "GlobalDeclaration";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
