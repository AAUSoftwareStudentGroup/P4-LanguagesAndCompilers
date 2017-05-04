using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class IdentifierStatementP : Compiler.Parsing.Data.Node
	{
		public  IdentifierStatementP()
		{
		}

		public  IdentifierStatementP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IdentifierStatementP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
