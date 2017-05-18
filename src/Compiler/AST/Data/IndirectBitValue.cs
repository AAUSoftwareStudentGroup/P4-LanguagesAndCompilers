using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IndirectBitValue : Compiler.AST.Data.Node
	{
		public  IndirectBitValue()
		{
			Id = NextId;
		}

		public  IndirectBitValue(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "IndirectBitValue";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
