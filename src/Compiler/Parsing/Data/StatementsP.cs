using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class StatementsP : Compiler.Parsing.Data.Node
	{
		public  StatementsP()
		{
		}

		public  StatementsP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "StatementsP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
