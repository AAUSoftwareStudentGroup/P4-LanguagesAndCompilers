using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ElseStatement : Compiler.Parsing.Data.Node
	{
		public  ElseStatement()
		{
		}

		public  ElseStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ElseStatement";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
