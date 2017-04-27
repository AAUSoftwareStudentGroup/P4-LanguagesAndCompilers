using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class PowExpressionP : Compiler.Parsing.Data.Node
	{
		public  PowExpressionP()
		{
		}

		public  PowExpressionP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "PowExpressionP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
