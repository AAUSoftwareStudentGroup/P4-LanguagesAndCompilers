using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class RelationalExpressionP : Compiler.Parsing.Data.Node
	{
		public  RelationalExpressionP()
		{
			Id = NextId;
		}

		public  RelationalExpressionP(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "RelationalExpressionP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
