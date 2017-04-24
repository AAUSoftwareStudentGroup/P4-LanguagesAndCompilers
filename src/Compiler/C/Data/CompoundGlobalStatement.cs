using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class CompoundGlobalStatement : Compiler.C.Data.Node
	{
		public  CompoundGlobalStatement()
		{
		}

		public  CompoundGlobalStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "CompoundGlobalStatement";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
