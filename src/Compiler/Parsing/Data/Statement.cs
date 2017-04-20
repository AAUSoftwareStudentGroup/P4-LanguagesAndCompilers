using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class Statement : Compiler.Parsing.Data.Node
	{
		public  Statement()
		{
		}

		public  Statement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
