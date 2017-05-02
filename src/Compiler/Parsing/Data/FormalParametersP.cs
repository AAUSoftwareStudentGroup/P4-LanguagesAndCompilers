using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class FormalParametersP : Compiler.Parsing.Data.Node
	{
		public  FormalParametersP()
		{
		}

		public  FormalParametersP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "FormalParametersP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
