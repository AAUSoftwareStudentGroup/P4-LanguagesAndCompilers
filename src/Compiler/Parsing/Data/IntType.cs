using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class IntType : Compiler.Parsing.Data.Node
	{
		public  IntType()
		{
		}

		public  IntType(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntType";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
