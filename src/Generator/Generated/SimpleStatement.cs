using System.Collections.Generic;

namespace Generator.Generated
{
	public class SimpleStatement : Node
	{
		public override void Accept(Visitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
