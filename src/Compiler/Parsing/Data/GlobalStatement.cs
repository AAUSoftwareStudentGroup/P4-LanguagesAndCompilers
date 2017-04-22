using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class GlobalStatement : Compiler.Parsing.Data.Node
	{
		public  GlobalStatement()
		{
		}

		public  GlobalStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "GlobalStatement";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
