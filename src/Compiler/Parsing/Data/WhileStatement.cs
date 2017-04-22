using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class WhileStatement : Compiler.Parsing.Data.Node
	{
		public  WhileStatement()
		{
		}

		public  WhileStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "WhileStatement";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
