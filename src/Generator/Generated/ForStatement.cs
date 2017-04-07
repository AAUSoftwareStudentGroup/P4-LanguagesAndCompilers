using System.Collections.Generic;

namespace Generator.Generated
{
	public class ForStatement : Node
	{
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
