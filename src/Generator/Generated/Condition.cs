using System.Collections.Generic;

namespace Generator.Generated
{
	public class Condition : Node
	{
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
