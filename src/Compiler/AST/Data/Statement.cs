using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class Statement : Compiler.AST.Data.Node
	{
		public  Statement()
		{
		}

		public  Statement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
