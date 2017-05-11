using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class InterruptStatement : Compiler.AST.Data.Node
	{
		public  InterruptStatement()
		{
		}

		public  InterruptStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "InterruptStatement";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
