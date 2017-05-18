using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class IdentifierStatementP : Compiler.Parsing.Data.Node
	{
		public  IdentifierStatementP()
		{
			Id = NextId;
		}

		public  IdentifierStatementP(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "IdentifierStatementP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
