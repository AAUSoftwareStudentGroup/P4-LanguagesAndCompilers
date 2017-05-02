using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class FormalParameter : Compiler.Parsing.Data.Node
	{
		public  FormalParameter()
		{
		}

		public  FormalParameter(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "FormalParameter";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
