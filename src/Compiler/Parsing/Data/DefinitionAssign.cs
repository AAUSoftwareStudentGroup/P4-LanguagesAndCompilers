using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class DefinitionAssign : Compiler.Parsing.Data.Node
	{
		public  DefinitionAssign()
		{
			Id = NextId;
		}

		public  DefinitionAssign(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "DefinitionAssign";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
