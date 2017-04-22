using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class IfStatement : Compiler.Parsing.Data.Node
	{
		public  IfStatement()
		{
		}

		public  IfStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IfStatement";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}