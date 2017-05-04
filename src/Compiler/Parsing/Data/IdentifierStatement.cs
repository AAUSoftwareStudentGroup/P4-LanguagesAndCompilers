using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class IdentifierStatement : Compiler.Parsing.Data.Node
	{
		public  IdentifierStatement()
		{
		}

		public  IdentifierStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IdentifierStatement";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
