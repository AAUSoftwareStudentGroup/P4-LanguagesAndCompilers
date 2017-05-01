using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class Assignment : Compiler.Parsing.Data.Node
	{
		public  Assignment()
		{
		}

		public  Assignment(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Assignment";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
