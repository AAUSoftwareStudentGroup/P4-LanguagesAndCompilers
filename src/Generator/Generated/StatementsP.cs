using System.Collections.Generic;

namespace Generator.Generated
{
	public class StatementsP : Node
	{
		public override void Accept(Visitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
