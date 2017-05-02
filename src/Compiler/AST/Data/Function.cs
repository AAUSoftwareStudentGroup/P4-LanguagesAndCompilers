using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class Function : Compiler.AST.Data.Node
	{
		public  Function()
		{
		}

		public  Function(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Function";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
