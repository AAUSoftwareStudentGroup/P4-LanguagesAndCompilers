using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class FormalParameter : Compiler.C.Data.Node
	{
		public  FormalParameter()
		{
		}

		public  FormalParameter(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "FormalParameter";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
