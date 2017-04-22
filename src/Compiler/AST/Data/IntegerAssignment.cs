using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerAssignment : Compiler.AST.Data.Node
	{
		public  IntegerAssignment()
		{
		}

		public  IntegerAssignment(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerAssignment";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
