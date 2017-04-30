using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class Initialization : Compiler.Parsing.Data.Node
	{
		public  Initialization()
		{
		}

		public  Initialization(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Initialization";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
