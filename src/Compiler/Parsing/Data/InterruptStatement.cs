using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class InterruptStatement : Compiler.Parsing.Data.Node
	{
		public  InterruptStatement()
		{
		}

		public  InterruptStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "InterruptStatement";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
