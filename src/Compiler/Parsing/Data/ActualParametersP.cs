using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ActualParametersP : Compiler.Parsing.Data.Node
	{
		public  ActualParametersP()
		{
		}

		public  ActualParametersP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ActualParametersP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
