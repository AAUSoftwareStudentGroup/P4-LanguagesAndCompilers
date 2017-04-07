using System.Collections.Generic;

namespace Generator.Generated
{
	public class B : Node
	{
		public override void Accept(Visitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
