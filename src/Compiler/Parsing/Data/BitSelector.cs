using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class BitSelector : Compiler.Parsing.Data.Node
	{
		public  BitSelector()
		{
		}

		public  BitSelector(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BitSelector";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
