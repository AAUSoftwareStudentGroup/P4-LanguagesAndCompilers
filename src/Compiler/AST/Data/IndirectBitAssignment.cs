using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IndirectBitAssignment : Compiler.AST.Data.Node
	{
		public  IndirectBitAssignment()
		{
		}

		public  IndirectBitAssignment(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IndirectBitAssignment";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}