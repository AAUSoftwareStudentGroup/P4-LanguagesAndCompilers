using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class Main : Compiler.C.Data.Node
	{
		public  Main()
		{
		}

		public  Main(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Main";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
