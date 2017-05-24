using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class SimpleDefinition : Compiler.Parsing.Data.Node
	{
		public  SimpleDefinition()
		{
			Id = NextId;
		}

		public  SimpleDefinition(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "SimpleDefinition";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
