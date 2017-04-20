using System.Collections.Generic;

namespace Compiler.Translation.SymbolTable.Data
{
	public class ListNode : Compiler.Translation.SymbolTable.Data.Node
	{
		public  ListNode()
		{
		}

		public  ListNode(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
