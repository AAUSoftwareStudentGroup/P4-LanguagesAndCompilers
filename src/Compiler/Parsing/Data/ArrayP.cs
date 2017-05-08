using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ArrayP : Compiler.Parsing.Data.Node
	{
		public  ArrayP()
		{
		}

		public  ArrayP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ArrayP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
