using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class ListNode : Compiler.AST.Data.Node
	{
		public  ListNode()
		{
		}

		public  ListNode(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
