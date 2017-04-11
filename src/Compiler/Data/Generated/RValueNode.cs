using System.Collections.Generic;
using Compiler.Visitors;

namespace Compiler.Data
{
	public class RValueNode : Node
	{
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
