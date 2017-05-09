using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class Array : Compiler.Parsing.Data.Node
	{
		public  Array()
		{
		}

		public  Array(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Array";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
