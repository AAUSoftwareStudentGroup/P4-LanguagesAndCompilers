using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class GlobalStatements : Compiler.Parsing.Data.Node
	{
		public  GlobalStatements()
		{
		}

		public  GlobalStatements(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "GlobalStatements";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}