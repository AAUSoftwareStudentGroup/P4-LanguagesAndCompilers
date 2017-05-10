using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IfElseIfStatement : Compiler.AST.Data.Node
	{
		public  IfElseIfStatement()
		{
		}

		public  IfElseIfStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IfElseIfStatement";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
