using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerReturn : Compiler.AST.Data.Node
	{
		public  IntegerReturn()
		{
		}

		public  IntegerReturn(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerReturn";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
