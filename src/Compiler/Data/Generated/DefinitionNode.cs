using System.Collections.Generic;
using Compiler.Parsing;

namespace Compiler.Data
{
	public class DefinitionNode : Node
	{
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
