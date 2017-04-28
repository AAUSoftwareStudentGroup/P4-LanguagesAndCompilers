using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ForStatement : Compiler.Parsing.Data.Node
	{
		public  ForStatement()
		{
		}

		public  ForStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ForStatement";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
