using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ActualParameters : Compiler.Parsing.Data.Node
	{
		public  ActualParameters()
		{
		}

		public  ActualParameters(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ActualParameters";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
