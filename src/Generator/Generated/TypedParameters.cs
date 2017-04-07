using System.Collections.Generic;

namespace Generator.Generated
{
	public class TypedParameters : Node
	{
		public override void Accept(Visitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
