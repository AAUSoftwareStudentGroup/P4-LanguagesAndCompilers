using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class FormalParameters : Compiler.Parsing.Data.Node
	{
		public  FormalParameters()
		{
		}

		public  FormalParameters(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "FormalParameters";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
