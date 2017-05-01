using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class Declarations : Compiler.C.Data.Node
	{
		public  Declarations()
		{
		}

		public  Declarations(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Declarations";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
