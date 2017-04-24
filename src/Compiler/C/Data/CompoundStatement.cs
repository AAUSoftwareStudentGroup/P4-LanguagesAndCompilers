using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class CompoundStatement : Compiler.C.Data.Node
	{
		public  CompoundStatement()
		{
		}

		public  CompoundStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "CompoundStatement";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
