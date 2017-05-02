using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class Definition : Compiler.Parsing.Data.Node
	{
		public  Definition()
		{
		}

		public  Definition(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Definition";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
