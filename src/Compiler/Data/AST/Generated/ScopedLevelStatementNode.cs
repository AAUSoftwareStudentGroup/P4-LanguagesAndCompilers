using Compiler.Shared;
using System.Collections.Generic;
using Compiler.Visitors;

namespace Compiler.Data.AST
{
	public class ScopedLevelStatementNode : Node
	{
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
