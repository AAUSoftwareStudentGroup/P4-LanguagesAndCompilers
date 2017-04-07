using System.Collections.Generic;

namespace Generator.Generated
{
	public class Definition : Node
	{
		public override void Accept(Visitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
