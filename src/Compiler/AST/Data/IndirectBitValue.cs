using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IndirectBitValue : Compiler.AST.Data.Node
	{
		public  IndirectBitValue()
		{
		}

		public  IndirectBitValue(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
