using System.Collections.Generic;
using Compiler.Parsing.Generated;
using Compiler.Data;
using Compiler.Parsing;

namespace Compiler.Data.Generated
{
	public class AssignmentNode : Node
	{
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
