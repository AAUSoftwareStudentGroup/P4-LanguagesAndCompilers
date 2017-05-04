using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class IdentifierOperation : Compiler.Parsing.Data.Node
	{
		public  IdentifierOperation()
		{
		}

		public  IdentifierOperation(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IdentifierOperation";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
