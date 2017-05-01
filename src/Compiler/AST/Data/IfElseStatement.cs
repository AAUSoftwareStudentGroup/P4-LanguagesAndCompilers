using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IfElseStatement : Compiler.AST.Data.Node
	{
		public  IfElseStatement()
		{
		}

		public  IfElseStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IfElseStatement";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
