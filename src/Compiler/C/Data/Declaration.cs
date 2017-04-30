using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class Declaration : Compiler.C.Data.Node
	{
		public  Declaration()
		{
		}

		public  Declaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Declaration";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
