using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class DirectBitAssignment : Compiler.AST.Data.Node
	{
		public  DirectBitAssignment()
		{
		}

		public  DirectBitAssignment(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
