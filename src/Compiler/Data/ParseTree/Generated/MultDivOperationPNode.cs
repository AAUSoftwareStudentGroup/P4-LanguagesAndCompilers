using Compiler.Shared;
using System.Collections.Generic;
using Compiler.Visitors;

namespace Compiler.Data.ParseTree
{
	public class MultDivOperationPNode : Node
	{
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
