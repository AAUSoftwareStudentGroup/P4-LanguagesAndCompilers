using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class WhileStatement : Compiler.AST.Data.Node
	{
		public  WhileStatement()
		{
		}

		public  WhileStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "WhileStatement";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}