using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IfStatement : Compiler.AST.Data.Node
	{
		public  IfStatement()
		{
		}

		public  IfStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
