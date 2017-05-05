using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ReturnStatement : Compiler.Parsing.Data.Node
	{
		public  ReturnStatement()
		{
		}

		public  ReturnStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ReturnStatement";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
