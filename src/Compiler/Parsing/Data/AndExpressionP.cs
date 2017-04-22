using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class AndExpressionP : Compiler.Parsing.Data.Node
	{
		public  AndExpressionP()
		{
		}

		public  AndExpressionP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "AndExpressionP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
