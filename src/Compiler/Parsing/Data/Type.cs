using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class Type : Compiler.Parsing.Data.Node
	{
		public  Type()
		{
		}

		public  Type(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Type";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
