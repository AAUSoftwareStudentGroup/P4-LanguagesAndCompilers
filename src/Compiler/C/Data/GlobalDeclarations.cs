using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class GlobalDeclarations : Compiler.C.Data.Node
	{
		public  GlobalDeclarations()
		{
		}

		public  GlobalDeclarations(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "GlobalDeclarations";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
