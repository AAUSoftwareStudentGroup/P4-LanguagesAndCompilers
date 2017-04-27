using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class ModExpression : Compiler.C.Data.Node
	{
		public  ModExpression()
		{
		}

		public  ModExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ModExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
