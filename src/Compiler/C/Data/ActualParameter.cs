using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class ActualParameter : Compiler.C.Data.Node
	{
		public  ActualParameter()
		{
		}

		public  ActualParameter(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ActualParameter";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
