using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class Statement : Compiler.C.Data.Node
	{
		public  Statement()
		{
		}

		public  Statement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Statement";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
