using System.Collections.Generic;
using Compiler.Visitors;

namespace Compiler.Data
{
	public class IfStatementNode : Node
	{
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
