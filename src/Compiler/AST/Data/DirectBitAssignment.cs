using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class DirectBitAssignment : Compiler.AST.Data.Node
	{
		public  DirectBitAssignment()
		{
			Id = NextId;
		}

		public  DirectBitAssignment(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "DirectBitAssignment";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
