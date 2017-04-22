using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ListNode : Compiler.Parsing.Data.Node
	{
		public  ListNode()
		{
		}

		public  ListNode(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}