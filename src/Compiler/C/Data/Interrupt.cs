using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class Interrupt : Compiler.C.Data.Node
	{
		public  Interrupt()
		{
		}

		public  Interrupt(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Interrupt";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
